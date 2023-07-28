public class Solution {
    public class Node {
        public bool IsWord {get; set;} = false;
        public Dictionary<char, Node> Children {get; set;} = new ();
    }

    private Node _root = new ();
    private string _s;
    private bool _result = false;
    private bool?[] _mem;

    private bool F(int index) {
        if (index == _s.Length) {
            return true;
        }
        if (_mem[index] != null) {
            return _mem[index].Value;
        }

        var cur = _root;
        var result = false;
        for (int i = index; i < _s.Length; i++) {
            var c = _s[i];
            if (!cur.Children.ContainsKey(c)) {
                break;
            }
            cur = cur.Children[c];
            if (cur.IsWord) {
                result |= F(i+1);
            }
        }

        _mem[index] = result;
        return result;
    }

    // Passes
    public bool WordBreak(string s, IList<string> wordDict) {

        // buildTree
        foreach (var w in wordDict) {
            var cur = _root;
            foreach (var c in w) {
                if (!cur.Children.ContainsKey(c)) {
                    cur.Children[c] = new Node();
                }
                cur = cur.Children[c];
            }
            cur.IsWord = true;
        }

        _s = s;
        _mem = new bool?[_s.Length];

        return F(0);
    }
}