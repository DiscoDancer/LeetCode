public class Solution {
    public int LengthOfLastWord(string s) {
        var r = s.Length - 1;
        while (s[r] == ' ') {
            r--;
        }

        var l = r;
        while (l - 1 >= 0 && s[l - 1] != ' ') {
            l--;
        }

        return r - l + 1;
    }
}