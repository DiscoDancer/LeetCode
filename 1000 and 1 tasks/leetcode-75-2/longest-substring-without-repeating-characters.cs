public class Solution {
    // хранить индексы
    // оптимизация в массив

    // можно убрать hs и мб PriorityQueue<(char c, int i), int> -> PriorityQueue<char, int> потому что есть таблица
    public int LengthOfLongestSubstring(string s) {
        var table = new Dictionary<char, int>();

        var maxLength = 0;

        var hs = new HashSet<char>();
        var minHeap = new PriorityQueue<(char c, int i), int>();

        for (int i = 0; i < s.Length; i++) {
            if (hs.Add(s[i])) {
                table[s[i]] = i;
                minHeap.Enqueue((s[i], i), i);
            }
            else {
                var lastIndex = table[s[i]];

                // todo удалить все до lastIndex (включая)
                while (minHeap.Count > 0 && minHeap.Peek().i <= lastIndex) {
                    var cur = minHeap.Dequeue();
                    hs.Remove(cur.c);
                    table.Remove(cur.c);
                }

                hs.Add(s[i]);
                table[s[i]] = i;
                minHeap.Enqueue((s[i], i), i);
            }

            maxLength = Math.Max(maxLength, hs.Count());
        }

        return maxLength;
    }
}