public class Solution {
    // editorial (not better than mine)
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        var n = s.Length;
        if (n < 3) {
            return n;
        }

        var left = 0;
        var right = 0;
        var hashmap = new Dictionary<char, int>();
        var max = 2;

        while (right < n) {
            hashmap[s[right]] = right++;
            if (hashmap.Keys.Count() == 3) {
                var del_idx = hashmap.Values.Min();
                hashmap.Remove(s[del_idx]);
                left = del_idx + 1;
            }

            max = Math.Max(max, right-left);
        }

        return max;
    }
}