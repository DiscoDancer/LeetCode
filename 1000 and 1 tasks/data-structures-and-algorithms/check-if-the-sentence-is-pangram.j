import java.util.Arrays;

class Solution {
    public boolean checkIfPangram(String sentence) {
        var table = new boolean[26];

        for (var i = 0; i < sentence.length(); i++) {
            var ch = sentence.charAt(i);
            table[ch - 'a'] = true;
        }

        for (var i = 0; i < 26; i++) {
            if (!table[i]) {
                return false;
            }
        }

        return true;
    }
}