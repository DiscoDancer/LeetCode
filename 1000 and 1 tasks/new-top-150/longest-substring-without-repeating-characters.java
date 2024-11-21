import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

class Solution {
    public int lengthOfLongestSubstring(String s) {
        var maxLength = 0;
        var charTable = new HashMap<Character, Integer>();

        var left = 0;
        for (var right = 0; right < s.length(); right++) {
            var c = s.charAt(right);
            if (!charTable.containsKey(c) || charTable.get(c) < left) {
                maxLength = Math.max(maxLength, right - left + 1);
            } else {
                left = charTable.get(c) + 1;
            }
            charTable.put(c, right);
        }

        return maxLength;
    }
}