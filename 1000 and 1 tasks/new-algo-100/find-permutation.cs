public class Solution {
    // wiggle sort
    // создать массив от 1 до n и менять местами рассматривая по несколько (2-3)
    // комбинации могут быть II, ID, DD, DI; Нет, потому что не сработает для DDDDDDDD
    // если читать с конца
    // просто захватывать предыдущий
    public int[] FindPermutation(string s) {
        var defaultQueue = new Queue<int>();
        for (int i = 1; i <= s.Length + 1; i++) {
            defaultQueue.Enqueue(i);
        }

        var rdyQueue = new List<int>();

        for (int i = 0; i < s.Length; ) {
            var cur = s[i];
            if (cur == 'I') {
                var buffer = new Queue<int>();
                if (i > 0) {
                    buffer.Enqueue(rdyQueue.Last());
                    rdyQueue.RemoveAt(rdyQueue.Count()-1);
                }
                while (i < s.Length && s[i] == 'I') {
                    if (i == 0) {
                        buffer.Enqueue(defaultQueue.Dequeue());
                        buffer.Enqueue(defaultQueue.Dequeue());
                    } else {
                        buffer.Enqueue(defaultQueue.Dequeue());
                    }
                    i++;
                }
                while (buffer.Any()) {
                    rdyQueue.Add(buffer.Dequeue());
                }
            }
            else if (cur == 'D') {
                var buffer = new Stack<int>();
                if (i > 0) {
                    buffer.Push(rdyQueue.Last());
                    rdyQueue.RemoveAt(rdyQueue.Count()-1);
                }
                while (i < s.Length && s[i] == 'D') {
                    if (i == 0) {
                        buffer.Push(defaultQueue.Dequeue());
                        buffer.Push(defaultQueue.Dequeue());
                    } else {
                        buffer.Push(defaultQueue.Dequeue());
                    }
                    i++;
                }
                while (buffer.Any()) {
                    rdyQueue.Add(buffer.Pop());
                }
            }
        }

        return rdyQueue.ToArray();
    }
}