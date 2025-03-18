import java.util.ArrayDeque;
import java.util.List;

class Solution {

    public String longestPalindrome(String s) {
        var max = 0;
        String longest = "";

        // single middle
        for (var middleIndex = 0; middleIndex < s.length(); middleIndex++) {

            var l = middleIndex - 1;
            var r = middleIndex + 1;

            if (1 > max) {
                max = 1;
                longest = s.substring(middleIndex, middleIndex + 1);
            }

            var length = 1;
            while (l >= 0 && r < s.length() && s.charAt(l) == s.charAt(r)) {
                length+=2;

                if (length > max) {
                    max = length;
                    longest = s.substring(l, r+1);
                }

                r++;
                l--;
            }

            // even middle
            if (middleIndex < s.length() - 1 && s.charAt(middleIndex) == s.charAt(middleIndex + 1)) {

                length = 2;

                l = middleIndex - 1;
                r = middleIndex + 2;

                if (2 > max) {
                    max = 2;
                    longest = s.substring(middleIndex, middleIndex + 2);
                }

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
        }


        return longest;
    }
}
