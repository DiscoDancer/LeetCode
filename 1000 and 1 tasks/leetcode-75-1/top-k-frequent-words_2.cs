public class Solution {
    private int _k;
    private List<string> _res = new List<string>();

    public class TrieNode {
        public TrieNode[] children;
        public bool isWord;

        public TrieNode() {
            children = new TrieNode[26];
            isWord = false;
        }
    }

    private void UploadWords(TrieNode root, string prefix) {
         if (_k == 0) {
            return;
         }
         if (root.isWord) {
             _k--;
             _res.Add(prefix);
         }
         for (int i = 0; i < 26; i++) {
             if (root.children[i] != null) {
                 UploadWords(root.children[i], prefix + (char) (i + 'a'));
             }
         }
    }

    private void AddWord(TrieNode root, string word) {
        TrieNode cur = root;
        foreach (var c in word) {
            if (cur.children[c - 'a'] == null) {
                cur.children[c - 'a'] = new TrieNode();
            }
            cur = cur.children[c - 'a'];
        }
        cur.isWord = true;
    }

    public IList<string> TopKFrequent(string[] words, int k) {
        _k = k;
        

        var frequencyByWord = new Dictionary<string, int>();
        foreach (var w in words) {
            if (!frequencyByWord.ContainsKey(w)) {
                frequencyByWord[w] = 0;
            }
            frequencyByWord[w]++;
        }

        var maxValue = frequencyByWord.Values.Max();
        var bucket = new TrieNode[maxValue + 1]; // зачем такой большой?

        foreach (var kvp in frequencyByWord) {
            if (bucket[frequencyByWord[kvp.Key]] == null) {
                bucket[frequencyByWord[kvp.Key]] = new TrieNode();
            }
            AddWord(bucket[frequencyByWord[kvp.Key]], kvp.Key);
        }

        var i = maxValue;
        while (i >= 1) {
            if (bucket[i] != null) {
                UploadWords(bucket[i], "");
                // todo upload words
            }
            i--;
            if (_k == 0) {
                break;
            }
        }

        return _res;
    }
}