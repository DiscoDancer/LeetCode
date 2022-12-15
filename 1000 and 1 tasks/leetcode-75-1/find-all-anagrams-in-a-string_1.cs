public class Solution {

    private char[] GetTable(string a, int? length = null) {
        var table = new char[26];

        if (length == null) {
            length = a.Length;
        }

        for (int i = 0; i < length; i++) {
            table[a[i] - 'a']++;
        }

        return table;
    }

    private bool AreTablesSame(char[] table1, char[] table2) {
        for (int i = 0; i < 26; i++) {
            if (table1[i] != table2[i]) {
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

        var pTable = GetTable(p);
        var sTable = GetTable(s, p.Length);

        var res = new List<int>();
        for (int i = 0; i <= s.Length - p.Length; i++) {
            if (AreTablesSame(pTable, sTable)) {
                res.Add(i);
            }
            sTable[s[i]-'a']--;
            if (i < s.Length - p.Length) {
                sTable[s[i + p.Length]-'a']++;
            }
        }

        return res as IList<int>;
    }
}