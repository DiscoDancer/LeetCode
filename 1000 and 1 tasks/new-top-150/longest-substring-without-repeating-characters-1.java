class Solution {
    public int lengthOfLongestSubstring(String s) {
        var maxLength = 0;
        var charTable = new Integer[128];

        var left = 0;
        for (var right = 0; right < s.length(); right++) {
            var c = (int)s.charAt(right);
            if (charTable[c] == null || charTable[c] < left) {
                maxLength = Math.max(maxLength, right - left + 1);
            } else {
                left = charTable[c] + 1;
            }
            charTable[c] = right;
        }

        return maxLength;
    }
}