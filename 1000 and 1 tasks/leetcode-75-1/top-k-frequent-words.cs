public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        var frequencyByWord = new Dictionary<string, int>();

        foreach (var w in words) {
            if (!frequencyByWord.ContainsKey(w)) {
                frequencyByWord[w] = 0;
            }
            frequencyByWord[w]++;
        }

        var wordsByFrequency = new Dictionary<int, List<string>>();
        foreach (var kvp in frequencyByWord) {
            if (!wordsByFrequency.ContainsKey(kvp.Value)) {
                wordsByFrequency[kvp.Value] = new List<string>();
            }
            wordsByFrequency[kvp.Value].Add(kvp.Key);
        }

        // desc
        var frequencies = wordsByFrequency.Keys.OrderBy(x => -x).ToArray();

        var i = 0;
        var res = new List<string>();
        while (i < k) {
            foreach (var fr in frequencies) {
                var frWords = wordsByFrequency[fr].OrderBy(x => x).ToArray();
                foreach (var w in frWords) {
                    res.Add(w);
                    i++;

                    if (i == k) {
                        return res;
                    }
                }
            }
        }

        return res;
    }
}