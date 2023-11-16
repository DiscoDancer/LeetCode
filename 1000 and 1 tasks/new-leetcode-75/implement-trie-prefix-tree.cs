public class Trie {

    public class Node {
        public Node(char c, bool isWord = false) {
            C = c;
            IsWord = isWord;
            Children = new Node[26];
        }

        public char C {get; set;}
        public bool IsWord {get; set;}
        public Node[] Children {get; set;}
    }

    private Node _root = null;

    public Trie() {
        _root = new Node((char)0);
    }
    
    public void Insert(string word) {
        var cur = _root;
        foreach (var c in word) {
            if (cur.Children[c-'a'] == null) {
                cur.Children[c-'a'] = new Node(c);
            }
            cur = cur.Children[c-'a'];
        }
        cur.IsWord = true; 
    }
    
    public bool Search(string word) {
        var cur = _root;
        foreach (var c in word) {
            if (cur.Children[c-'a'] == null) {
                return false;
            }
            cur = cur.Children[c-'a'];
        }

        return cur.IsWord;
    }
    
    public bool StartsWith(string prefix) {
        var cur = _root;
        foreach (var c in prefix) {
            if (cur.Children[c-'a'] == null) {
                return false;
            }
            cur = cur.Children[c-'a'];
        }

        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */