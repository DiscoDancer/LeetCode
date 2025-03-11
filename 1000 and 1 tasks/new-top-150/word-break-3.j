import java.util.List;

// TL

class Solution {

    public class TrieNode {
        public TrieNode[] children = new TrieNode[26];
        public boolean isWord = false;
    }

    public TrieNode root = new TrieNode();

    public String s;

    public boolean F(int i) {
        var result = false;

        var node = this.root;

        while (i < this.s.length() && node.children[this.s.charAt(i)-'a'] != null) {
            node = node.children[this.s.charAt(i)-'a'];
            if (node.isWord) {
                result = result || F(i + 1);
            }
            i++;
        }

        // либо мы сами дошли до конца, либо кто-то из детей дошел до конца
        result = result || i == s.length() && node.isWord;

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

        return F(0);
    }
}