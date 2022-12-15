public class Solution {

    private bool isAnagram(string a, string b) {
        var table = new char[26];

        foreach (var c in a) {
            table[c - 'a']++;
        }
        foreach (var c in b) {
            table[c - 'a']--;
        }

        for (int i = 0; i < 26; i++) {
            if (table[i] != 0) {
                return false;
            }
        }

        return true;
    }

    public IList<int> FindAnagrams(string s, string p) {
        if (s.Length < p.Length) {
            return new List<int>() as IList<int>;
        }
        if (s.Length == p.Length) {
            if (s == p) {
                return new List<int>() {0} as IList<int>;
            }
        }

        var res = new List<int>();
        for (int i = 0; i <= s.Length - p.Length; i++) {
            var sub = s.Substring(i, p.Length);
            if (isAnagram(sub, p)) {
                res.Add(i);
            }
        }

        return res as IList<int>;
    }
}