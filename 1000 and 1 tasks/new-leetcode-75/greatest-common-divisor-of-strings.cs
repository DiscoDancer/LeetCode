public class Solution {
    private bool IsDivisor(string s, string t) {
        if (t.Length == 0 || s.Length == 0) {
            return false;
        }

        if (s.Length % t.Length != 0) {
            return false;
        }

        var sb = new StringBuilder();
        for (int i = 0; i < s.Length / t.Length; i++) {
            sb.Append(t);
        }

        return s == sb.ToString();
    }

    public string GcdOfStrings(string str1, string str2) {
        var p1 = 0;
        var p2 = 0;
        while (p1 < str1.Length && p2 < str2.Length && str1[p1] == str2[p2]) {
            p1++;
            p2++;
        }

        for (int i = p1; i > 0; i--) {
            var pattern = str1.Substring(0, i);
            if (IsDivisor(str1, pattern) && IsDivisor(str2, pattern)) {
                return pattern;
            }
        }

        return "";
    }
}