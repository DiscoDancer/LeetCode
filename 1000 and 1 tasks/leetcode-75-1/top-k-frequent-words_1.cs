public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        var frequencyByWord = new Dictionary<string, int>();

        foreach (var w in words) {
            if (!frequencyByWord.ContainsKey(w)) {
                frequencyByWord[w] = 0;
            }
            frequencyByWord[w]++;
        }

        var uniqueWords = frequencyByWord.Keys.ToList();
        uniqueWords.Sort(LocalCompare);

        int LocalCompare(string x, string y) {
            if (frequencyByWord[x] != frequencyByWord[y]) {
                return - frequencyByWord[x].CompareTo(frequencyByWord[y]);
            }
            return x.CompareTo(y);
        }

        return uniqueWords.Take(k).ToList();
    }
}