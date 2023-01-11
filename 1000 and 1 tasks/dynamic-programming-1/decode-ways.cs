// TL
public class Solution {
    // такое же дерево префиксов
    // или конечный автомат
    // todo вспомнить их дерево префиксов
    public int NumDecodings(string s) {
        var hs = new HashSet<string>();
        for (int i = 1; i <= 26; i++) {
            hs.Add(i.ToString());
        }

        var queue = new Queue<int>();
        queue.Enqueue(0);
        var res = 0;

        while (queue.Any()) {
            var start = queue.Dequeue();

            for (var length = 1; start + length <= s.Length; length++) {
                var sub = s.Substring(start, length);
                var endIndex = start + length -1;
                if (hs.Contains(sub)) {
                     // если не последняя часть - кладем, если последняя не увеличиваем ответ
                    if (endIndex == s.Length - 1) {
                        res++;
                    }
                    else {
                        queue.Enqueue(start + length);
                    } 
                }
            }
        }

        return res;
    }
}