public class Solution {
    // https://leetcode.com/problems/word-ladder/solutions/239223/word-ladder/?orderBy=most_votes
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
          int L = beginWord.Length;

          // for mask get words
          var allComboDict = new Dictionary<string, List<string>>();

          foreach (var word in wordList) {
              for (int i = 0; i < L; i++) {
                  var sb = new StringBuilder(word);
                  sb[i] = '*';
                  var newWord = sb.ToString();

                  if (!allComboDict.ContainsKey(newWord)) {
                      allComboDict[newWord] = new List<string>();
                  }
                  allComboDict[newWord].Add(word);
              }
          }

        var queue = new Queue<(string w, int steps)>();
        queue.Enqueue((beginWord, 1));

        var visited = new HashSet<string>();
        visited.Add(beginWord);

        while (queue.Any()) {
            var (w, steps) = queue.Dequeue();
            if (w == endWord) {
                return steps;
            }

            for (int i = 0; i < L; i++) {
                var sb = new StringBuilder(w);
                sb[i] = '*';
                var mask = sb.ToString();

                if (!allComboDict.ContainsKey(mask)) {
                    continue;
                }

                var findings = allComboDict[mask].Where(x => !visited.Contains(x)).ToList();
                foreach (var f in findings) {
                    visited.Add(f);
                    queue.Enqueue((f, steps + 1));
                }
            }

        }

        return 0;
    }
}