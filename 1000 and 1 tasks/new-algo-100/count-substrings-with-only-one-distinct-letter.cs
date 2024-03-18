public class Solution {
    public int CountLetters(string s) {
        var i = 0;
        var result = 0;

        while (i < s.Length) {
            var cur = s[i];
            var strike = 1;
            i++;
            while (i < s.Length && s[i] == cur) {
                i++;
                strike++;
            }

            result += (1 + strike) * (strike) / 2;
        }

        return result;
    }
}