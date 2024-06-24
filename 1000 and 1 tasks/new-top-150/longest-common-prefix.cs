public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        var prev = strs[0];

        var longestCommonPrefix = strs[0].Length;

        for (int i = 1; i < strs.Length && longestCommonPrefix > 0; i++) {
            var cur = strs[i];
            var j = 0;
            while (j < Math.Min(cur.Length, prev.Length) && cur[j] == prev[j]) {
                j++;
            }
            longestCommonPrefix = Math.Min(j, longestCommonPrefix);
            prev = cur;
        }

        return strs[0].Substring(0, longestCommonPrefix);
    }
}