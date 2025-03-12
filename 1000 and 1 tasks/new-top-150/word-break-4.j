import java.util.List;

class Solution {

    public class TrieNode {
        public TrieNode[] children = new TrieNode[26];
        public boolean isWord = false;
    }

    public boolean wordBreak(String s, List<String> wordDict) {
        var root = new TrieNode();

        for (var word : wordDict) {
            var cur = root;
            for (var i = 0; i < word.length(); i++) {
                var c = word.charAt(i);
                if (cur.children[c - 'a'] == null) {
                    cur.children[c - 'a'] = new TrieNode();
                }
                cur = cur.children[c - 'a'];
            }
            cur.isWord = true;
        }

        var table = new boolean[s.length() + 1];
        table[s.length()] = true;

        for (var i = s.length() - 1; i >= 0; i--) {
            var result = false;
            var node = root;

            var j = i;
            while (j < s.length() && node.children[s.charAt(j) - 'a'] != null) {
                node = node.children[s.charAt(j) - 'a'];
                if (node.isWord) {
                    result = result || table[j + 1];
                }
                j++;
            }

            // либо мы сами дошли до конца, либо кто-то из детей дошел до конца
            result = result || i == s.length() && node.isWord;

            table[i] = result;
        }

        return table[0];
    }
}