public class Solution {
    public int LengthOfLastWord(string s) {
        var result = 0;

        var i = s.Length - 1;
        while (s[i] == ' ') {
            i--;
        }

        while (i >= 0 && s[i] != ' ') {
            i--;
            result++;
        }

        return result;
    }
}