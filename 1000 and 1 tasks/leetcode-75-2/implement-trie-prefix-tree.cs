public class Trie {

    public class Node {
        public Node() {}

        public Node(char c) {
            Char = c;
        }

        public bool IsWord { get; set; } = false;
        public char Char {get; set;}
        public Node[] Children {get; set;} = new Node[26];
    }

    private Node _root = new Node();

    public Trie() {
        
    }
    
    public void Insert(string word) {
        var cur = _root;
        for (int i = 0; i < word.Length; i++) {
            if (cur.Children[word[i] - 'a'] == null) {
                cur.Children[word[i] - 'a'] = new Node(word[i]);
            }
            if (i == word.Length - 1) {
                cur.Children[word[i] - 'a'].IsWord = true;
            }
            cur = cur.Children[word[i] - 'a'];
        }
    }
    
    public bool Search(string word) {
        var cur = _root;
        for (int i = 0; i < word.Length; i++) {
            if (cur.Children[word[i]-'a'] == null) {
                return false;
            }
            if (i == word.Length - 1 && cur.Children[word[i]-'a'].IsWord) {
                return true;
            }
            cur = cur.Children[word[i]-'a'];
        }

        return false;
    }
    
    public bool StartsWith(string prefix) {
        var cur = _root;
        for (int i = 0; i < prefix.Length; i++) {
            if (cur.Children[prefix[i]-'a'] == null) {
                return false;
            }
            cur = cur.Children[prefix[i]-'a'];
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