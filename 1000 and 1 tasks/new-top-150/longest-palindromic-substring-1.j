import java.util.ArrayDeque;
import java.util.List;

class Solution {

    private String s;
    private int max = 0;
    private String longest = "";

    private void expand(int l, int r, int length) {
        while (l >= 0 && r < s.length() && s.charAt(l) == s.charAt(r)) {
            length+=2;

            if (length > max) {
                max = length;
                longest = s.substring(l, r+1);
            }

            r++;
            l--;
        }
    }

    public String longestPalindrome(String s) {
        this.s = s;

        for (var middleIndex = 0; middleIndex < s.length(); middleIndex++) {
            // single middle
            if (1 > max) {
                max = 1;
                longest = s.substring(middleIndex, middleIndex + 1);
            }

            expand(middleIndex -1, middleIndex + 1, 1);

            // even middle
            if (middleIndex < s.length() - 1 && s.charAt(middleIndex) == s.charAt(middleIndex + 1)) {
                if (2 > max) {
                    max = 2;
                    longest = s.substring(middleIndex, middleIndex + 2);
                }

                expand(middleIndex -1, middleIndex + 2, 2);
            }
        }

        return longest;
    }
}
