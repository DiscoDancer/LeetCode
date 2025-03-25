import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {

    public class TrieNode {
        public TrieNode[] children = new TrieNode[26];
        public boolean isWord;
    }

    private TrieNode root;
    private String s;

    private boolean F(int i) {
        if (i == this.s.length()) {
            return true;
        }

        var result = false;

        var cur = this.root;
        var j = i;
        while (!result && j < this.s.length() && cur.children[this.s.charAt(j)-'a'] != null) {
            cur = cur.children[this.s.charAt(j)-'a'];
            j++;
            if (cur.isWord) {
                result = result || F(j);
            }
        }

        return result;
    }

    public boolean wordBreak(String s, List<String> wordDict) {
        this.root = new TrieNode();
        this.s = s;

        for (var w: wordDict) {
            var cur = this.root;
            for (int i = 0; i < w.length(); i++) {
                var c = w.charAt(i);
                if (cur.children[c - 'a'] == null) {
                    cur.children[c - 'a'] = new TrieNode();
                }
                cur = cur.children[c - 'a'];
            }
            cur.isWord = true;
        }

        return F(0);
    }
}
