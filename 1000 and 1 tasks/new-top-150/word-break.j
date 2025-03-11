import java.util.List;

// TL

class Solution {

    public class TrieNode {
        public TrieNode[] children = new TrieNode[26];
        public boolean isWord = false;
    }

    public TrieNode root = new TrieNode();

    public String s;
    public boolean wordFound = false;

    public void F(int i, TrieNode node) {
        if (i == s.length()) {
            wordFound = node.isWord;
            return;
        }
        if (wordFound) {
            return;
        }

        var c = s.charAt(i);
        if (node.children[c - 'a'] != null) {
            if (node.children[c - 'a'].isWord) {
                // continue with the next word
                F(i + 1, root);
            }
            // continue with the current word
            F(i + 1, node.children[c - 'a']);
        }
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

        F(0, this.root);

        return wordFound;
    }
}