public class Solution {
    public bool IsSubsequence(string s, string t) {
        if (s.Length > t.Length) {
            return false;
        }

        var ps = 0;
        var pt = 0;

        var matchCount = 0;

        while (ps < s.Length && pt < t.Length) {
            while (pt < t.Length && t[pt] != s[ps]) {
                pt++;
            }
            if (ps < s.Length && pt < t.Length && s[ps] == t[pt]) {
                matchCount++;
            }
            
            ps++;
            pt++; 
        }

        return matchCount == s.Length;
    }
}