public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if (beginWord == endWord) {
            return 0;
        }

        if (!wordList.Contains(endWord)) {
            return 0;
        }

        var queue = new Queue<string>();
        queue.Enqueue(beginWord);

        var copyBank = wordList.ToList();
        var generation = 1;
        while (queue.Any()) {
            var size = queue.Count();

            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                if (cur == endWord) {
                    return generation;
                }

                var optionsToDelete = new List<string>();

                foreach (var option in copyBank) {
                    var diffCount = 0;
                    for (int j = 0; j < option.Length && diffCount < 2; j++) {
                        if (option[j] != cur[j]) {
                            diffCount++;
                        }
                    }
                    if (diffCount == 1) {
                        queue.Enqueue(option);
                        optionsToDelete.Add(option);
                    }
                }

                foreach (var x in optionsToDelete) {
                    copyBank.Remove(x);
                }
            }
            generation++;
        }

        return 0;
    }
}