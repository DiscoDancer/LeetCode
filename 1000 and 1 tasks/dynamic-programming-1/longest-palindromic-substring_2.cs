public class Solution {
    // https://leetcode.com/problems/longest-palindromic-substring/solutions/127837/longest-palindromic-substring/
    public string LongestPalindrome(string s) {
        var max = 0;
        var start = 0;
        for (int i = 0; i < s.Length; i++) {
            var l1 = TryExpand(s, i, i);
            var l2 = TryExpand(s, i, i+1);
            var l = Math.Max(l1,l2);

            if (l > max) {
                max = l;
                start = i - (max - 1) / 2;
            }
        }

        return s.Substring(start, max);
    }

    public int TryExpand(string s, int l, int r) {
        while (l >= 0 && r <= s.Length -1 && s[l] == s[r]) {
            l--;
            r++;
        }
        return r-l-1 ;
    }
}