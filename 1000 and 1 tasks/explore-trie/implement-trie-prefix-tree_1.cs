public class Trie {

    public class Node {
        public Node[] children {get; set;}
        public bool end { get; set; }

        public Node() {
            children = new Node[26];
        }
    }

    public Node root = new Node();

    public Trie() {

    }
    
    public void Insert(string word) {
        var cur = root;
        foreach (var c in word) {
            if (cur.children[c-'a'] == null) {
                cur.children[c-'a'] = new Node();
            }
            cur = cur.children[c-'a'];
        }

        cur.end = true;
    }
    
    public bool Search(string word) {
        var curNode = root;
        var i = 0;
        while (i < word.Length && curNode != null) {
            var curLetter = word[i];
            if (curNode.children[curLetter-'a'] == null) {
                return false;
            }
            curNode = curNode.children[curLetter-'a'];
            i++;
        }

        return curNode != null && curNode.end;
    }
    
    public bool StartsWith(string prefix) {
        var curNode = root;
        for (int i = 0; i < prefix.Length; i++) {
            if (curNode == null) {
                return false;
            }
            if (curNode.children[prefix[i]-'a'] == null) {
                return false;
            }
            curNode = curNode.children[prefix[i]-'a'];
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