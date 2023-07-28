public class Solution {
    public class Node {
        public bool IsWord {get; set;} = false;
        public Dictionary<char, Node> Children {get; set;} = new ();
    }

    private Node _root = new ();
    private string _s;
    private bool _result = false;

    private void F(int index) {
        if (index == _s.Length) {
            _result = true;
        }
        if (_result) {
            return;
        }

        var cur = _root;
        for (int i = index; i < _s.Length; i++) {
            var c = _s[i];
            if (!cur.Children.ContainsKey(c)) {
                return;
            }
            cur = cur.Children[c];
            if (cur.IsWord) {
                F(i+1);
            }
        }
    }

    // TL
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

        F(0);

        return _result;
    }
}