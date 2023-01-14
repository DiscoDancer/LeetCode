public class Solution {

    public bool IsPalindrome(string s, int a, int b) {
        while (a < b) {
            if (s[a++] != s[b--]) {
                return false;
            }
        }
        return true;
    }

    public string LongestPalindrome(string s) {
        for (int length = s.Length; length >= 2; length--) {
            for (int start = 0; start + length <= s.Length;  start++) {
                var end = start + length - 1;
                if (IsPalindrome(s, start, end)) {
                    return s.Substring(start, length);
                }
            }
        }

        return s.Substring(0, 1);
    }
}