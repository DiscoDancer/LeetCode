import java.util.*;


class Solution {
    public int lengthOfLongestSubstring(String s) {
        if (s.length() == 0) {
            return 0;
        }

        // in case
        var state = new boolean[1024];
        var max = 1;
        state[s.charAt(0)] = true;


        var leftIncluding = 0;
        for (var rightIncluding = 1; rightIncluding < s.length(); rightIncluding++) {
            // если может, расширяемся
            if (!state[s.charAt(rightIncluding)]) {
                state[s.charAt(rightIncluding)] = true;
                max = Math.max(max, rightIncluding - leftIncluding + 1);
            } else {
                // иначе сужаемся
                while (s.charAt(leftIncluding) != s.charAt(rightIncluding)) {
                    state[s.charAt(leftIncluding)] = false;
                    leftIncluding++;
                }

                leftIncluding++;
            }
        }

        return max;
    }
}