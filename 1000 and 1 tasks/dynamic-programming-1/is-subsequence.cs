public class Solution {
    public bool IsSubsequence(string s, string t) {
        var pt = 0;

        for (int i = 0; i < s.Length; i++) {
            while (pt < t.Length && s[i] != t[pt]) {
                pt++;
            }
            if (pt >= t.Length) {
                return false;
            }
            pt++;
        }

        return true;
    }
}