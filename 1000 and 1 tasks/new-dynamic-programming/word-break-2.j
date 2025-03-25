import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {

    public class TrieNode {
        public TrieNode[] children = new TrieNode[26];
        public boolean isWord;
    }

    public boolean wordBreak(String s, List<String> wordDict) {
        var root = new TrieNode();

        for (var w: wordDict) {
            var cur = root;
            for (int i = 0; i < w.length(); i++) {
                var c = w.charAt(i);
                if (cur.children[c - 'a'] == null) {
                    cur.children[c - 'a'] = new TrieNode();
                }
                cur = cur.children[c - 'a'];
            }
            cur.isWord = true;
        }

        var table = new boolean[s.length()+1];
        for (var i = s.length(); i >= 0; i--) {
            if (i == s.length()) {
                table[i] = true;
            }
            else {
                var result = false;

                var cur = root;
                var j = i;
                while (!result && j < s.length() && cur.children[s.charAt(j)-'a'] != null) {
                    cur = cur.children[s.charAt(j)-'a'];
                    j++;
                    if (cur.isWord) {
                        result = result || table[j];
                    }
                }
                table[i] = result;
            }
        }

        return table[0];
    }
}
