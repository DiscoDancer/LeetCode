public class Solution {

    // размер окна на меняется

    /*
        Roadmap:
        + решить тупо
    */

    // l is same
    private bool IsPerm(string s1, string s2) {
        var table = new int[26];

        foreach (var c in s1) {
            table[c-'a']++;
        }

        foreach (var c in s2) {
            table[c-'a']--;
        }

        return table.All(x => x == 0);
    }

    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length) {
            return false;
        }

        for (int i = 0; i <= s2.Length - s1.Length; i++) {
            var sub = s2.Substring(i, s1.Length);
            if (IsPerm(s1, sub)) {
                return true;
            }
        }

        return false;
    }
}