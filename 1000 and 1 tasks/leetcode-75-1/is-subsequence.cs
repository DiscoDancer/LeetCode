public class Solution {
    public bool IsSubsequence(string s, string t) {
        if (s.Length > t.Length) {
            return false;
        }
        
        var n = t.Length;

        var j = t.Length - 1;
        for (var i = s.Length - 1; i >= 0; i--) {
            var c = s[i];

            while (j >= 0 && t[j] != c) {
                j--;
            }
            if (j < 0) {
                return false;
            }
            else if (t[j] == c) {
                j--;
            }
            else {
                return false;
            }
        }

        return true;
    }
}