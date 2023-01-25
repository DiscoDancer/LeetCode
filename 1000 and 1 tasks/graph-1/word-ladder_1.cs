public class Solution {
    // beginWord -> endWord (длина до 10)
    // wordList = промежуточные слова (большой до 500; unique)
    // lowercase letters
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var L = beginWord.Length;

        var visited = new HashSet<string>();
        visited.Add(beginWord);

        var queue = new Queue<(string w, int steps)>();
        queue.Enqueue((beginWord, 0));

        while (queue.Any()) {
            var (w, steps) = queue.Dequeue();
            if (w == endWord) {
                return steps + 1;
            }

            var goodList = new List<string>();

            foreach (var b in wordList) {
                var count = 0;
                for (int i = 0; i < L && count <= 1; i++) {
                    if (w[i] != b[i]) {
                        count++;
                    }
                }

                if (count == 1) {
                    goodList.Add(b);
                    visited.Add(b);
                    queue.Enqueue((b, steps + 1));
                }
            }

            foreach (var g in goodList) {
                wordList.Remove(g);
            }
        }

        return 0;
    }
}