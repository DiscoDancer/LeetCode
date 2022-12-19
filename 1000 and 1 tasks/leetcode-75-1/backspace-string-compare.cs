public class Solution {

    public bool IsEmpty(string s, int start) {
        var sIgnore = 0;
        while (start >= 0 && (s[start] == '#' || sIgnore > 0)) {
            if (s[start] == '#') {
                sIgnore++;
            }
            else {
                sIgnore--;
            }
            start--;
        }

        return start < 0;
    }

    public bool BackspaceCompare(string s, string t) {
        var ps = s.Length - 1;
        var pt = t.Length - 1;

        var sIgnore = 0;
        var tIgnore = 0;

        while (ps >= 0 && pt >= 0) {

            while ( ps >= 0 && (s[ps] == '#' || sIgnore > 0)) {
                if (s[ps] == '#') {
                    sIgnore++;
                }
                else {
                    sIgnore--;
                }
                ps--;
            }

            while ( pt >= 0 && (t[pt] == '#' || tIgnore > 0)) {
                if (t[pt] == '#') {
                    tIgnore++;
                } else {
                    tIgnore--;
                }
                pt--;
            }

            if (pt >= 0 && ps < 0 || pt < 0 && ps >= 0) {
                return false;
            }

            if (pt >= 0 && ps >= 0) {
                if (s[ps] != t[pt]) {
                    return false;
                }
            }
            
            ps--;
            pt--;
        }

        // выходим из цикла, если кто-то кончился
        // вторйо мог не кончится, но он должен быть пустым
        return IsEmpty(s, ps) && IsEmpty(t, pt);
    }
}