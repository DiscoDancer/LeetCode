public class Solution {
    public class Trie {
        public char Char {get; set;}
        public int Count {get; set;}
        public List<Trie> Children {get; set;} = new ();
    }

    public string LongestCommonPrefix(string[] strs) {
        if (strs.Length == 1) {
            return strs[0];
        }
        if (strs.Length == 0) {
            return "";
        }

        var root = new Trie();

        foreach (var str in strs) {
            var cur = root;
            foreach (var c in str) {
                var found = cur.Children.FirstOrDefault(x => x.Char == c);
                if (found != null) {
                    found.Count++;
                    cur = found;
                }
                else {
                    var nova = new Trie {
                        Char = c,
                        Count = 1,
                    };
                    cur.Children.Add(nova);
                    cur = nova;
                }
            }
        }

        var result = new List<char>();
        var cur2 = root;
        while (true) {
            var found = cur2.Children.FirstOrDefault(x => x.Count == strs.Length);
            if (found == null) {
                break;
            }
            result.Add(found.Char);
            cur2 = found;
        }

        return new string(result.ToArray());
    }
}