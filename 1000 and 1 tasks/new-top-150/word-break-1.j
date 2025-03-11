import java.util.List;

// TL

class Solution {

    public class TrieNode {
        public TrieNode[] children = new TrieNode[26];
        public boolean isWord = false;
    }

    public TrieNode root = new TrieNode();

    public String s;

    public boolean F(int i, TrieNode node) {
        if (i == s.length()) {
            return node.isWord;
        }

        var result = false;

        var c = s.charAt(i);
        if (node.children[c - 'a'] != null) {
            if (node.children[c - 'a'].isWord) {
                // continue with the next word
                result = result || F(i + 1, root);
            }
            // continue with the current word
            result = result || F(i + 1, node.children[c - 'a']);
        }

        return result;
    }

    public boolean wordBreak(String s, List<String> wordDict) {
        this.root = new TrieNode();

        for (var word : wordDict) {
            var cur = this.root;
            for (var i = 0; i < word.length(); i++) {
                var c = word.charAt(i);
                if (cur.children[c - 'a'] == null) {
                    cur.children[c - 'a'] = new TrieNode();
                }
                cur = cur.children[c - 'a'];
            }
            cur.isWord = true;
        }

        this.s = s;

        return F(0, this.root);
    }
}