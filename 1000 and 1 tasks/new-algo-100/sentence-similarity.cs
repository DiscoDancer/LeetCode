public class Solution {
    // union find not work (similarity relation is not transitive)
    // encode strings
    public bool AreSentencesSimilar(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs) {
        if (sentence1.Length != sentence2.Length) {
            return false;
        }

        var similarTable = new Dictionary<string, HashSet<string>>();
        foreach (var pair in similarPairs) {
            var a = pair[0];
            var b = pair[1];

            if (!similarTable.ContainsKey(a)) {
                similarTable[a] = new ();
            }
            if (!similarTable.ContainsKey(b)) {
                similarTable[b] = new ();
            }

            similarTable[a].Add(b);
            similarTable[b].Add(a);
        }

        for (int i = 0; i < sentence1.Length; i++) {
            var a = sentence1[i];
            var b = sentence2[i];
            
            if (a == b) {
                continue;
            }

            if (similarTable.ContainsKey(a) && similarTable[a].Contains(b)) {
                continue;
            }

            return false;
        }

        return true;
    }
}