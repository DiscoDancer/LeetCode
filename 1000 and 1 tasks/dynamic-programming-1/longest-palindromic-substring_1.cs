public class Solution {

    // abcde палиндром если bcd палиндром и a = e

    public bool IsPalindrome2(string s) {
        if (s.Length <= 1) {
            return true;
        }
        else if (s.Length <= 3) {
            return s[0] == s[s.Length -1];
        }

        return s[0] == s[s.Length -1] && IsPalindrome2(s.Substring(1, s.Length - 2));
    }

    public bool IsPalindrome3(string s, int a, int b) {
        var length = b - a + 1;
        if (length <= 1) {
            return true;
        }
        else if (length <= 3) {
            return s[a] == s[b];
        }

        return s[a] == s[b] && IsPalindrome3(s, a +1, b-1);
    }

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
                if (IsPalindrome3(s, start, end)) {
                    return s.Substring(start, length);
                }
            }
        }

        return s.Substring(0, 1);
    }
}