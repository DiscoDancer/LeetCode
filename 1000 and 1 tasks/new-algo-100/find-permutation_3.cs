public class Solution {
    // wiggle sort
    // создать массив от 1 до n и менять местами рассматривая по несколько (2-3)
    // комбинации могут быть II, ID, DD, DI; Нет, потому что не сработает для DDDDDDDD
    // если читать с конца
    // просто захватывать предыдущий
    public int[] FindPermutation(string s) {
        var rdyQueue = new List<int>() {1};
        var nextValue = 2;

        for (int i = 0; i < s.Length; ) {
            if (s[i] == 'I') {
                var buffer = new Queue<int>();
                buffer.Enqueue(rdyQueue.Last());
                rdyQueue.RemoveAt(rdyQueue.Count()-1);
                while (i < s.Length && s[i] == 'I') {
                    buffer.Enqueue(nextValue++);
                    i++;
                }
                while (buffer.Any()) {
                    rdyQueue.Add(buffer.Dequeue());
                }
            }
            else if (s[i] == 'D') {
                var buffer = new Stack<int>();
                buffer.Push(rdyQueue.Last());
                rdyQueue.RemoveAt(rdyQueue.Count()-1);
                while (i < s.Length && s[i] == 'D') {
                    buffer.Push(nextValue++);
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