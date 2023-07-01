public class Solution {
    // build Trie
    // обойти с backtracking

    public class Node {
        public Node(char v) {
            val = v;
        }

        public char val {get; set;}
        public int count {get; set;} = 1;
        public Node[] children = new Node[26];
    }

    public Node _root = new Node('.');
    public string _result = "";
    public int _target = 0;

    public void Traverse(Node cur, List<char> list) {
        if (list.Count() > _result.Length) {
            _result = new string(list.ToArray());
        }

        for (int i = 0; i < 26; i++) {
            if (cur.children[i] != null && cur.children[i].count == _target) {
                var copy = list.ToList();
                copy.Add((char)('a' + i));
                Traverse(cur.children[i], copy);
            }
        }
    }

    public string LongestCommonPrefix(string[] strs) {
        _target = strs.Length;

        foreach (var s in strs) {
            var cur = _root;
            foreach (var c in s) {
                var index = c - 'a';
                if (cur.children[index] == null) {
                    cur.children[index] = new Node(c);
                }
                else {
                    cur.children[index].count++;
                }
                cur = cur.children[index];
            }
        }

        Traverse(_root, new List<char> () {});

        return _result;
    }
}