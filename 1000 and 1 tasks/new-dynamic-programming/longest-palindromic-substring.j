import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


// editorial но я вспомнил сам
// еще можно через 4 квадрата и range queries

class Solution {

    private int max = 0;
    private String maxString = "";
    private String s;

    private void tryExpand(int l, int r, int curLength) {
        while (l >= 0 && r < s.length() && s.charAt(l) == s.charAt(r)) {
            curLength += 2;
            if (curLength > max) {
                max = curLength;
                maxString = s.substring(l, r + 1);
            }
            l--;
            r++;
        }
    }

    public String longestPalindrome(String s) {
        this.s = s;

        for (int i = 0; i < s.length(); i++) {
            // режим 1
            if (1 > max) {
                max = 1;
                maxString = s.substring(i, i + 1);
            }
            tryExpand(i, i, 1);

            if (i < s.length() - 1 && s.charAt(i) == s.charAt(i + 1)) {
                // режим 2
                if (2 > max) {
                    max = 2;
                    maxString = s.substring(i, i + 2);
                }
                tryExpand(i, i + 1, 2);
            }
        }


        return maxString;
    }
}
