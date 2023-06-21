public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        var dictionaryS = new Dictionary<char, int>();
        var indexS = 1;
        var dictionaryT = new Dictionary<char, int>();
        var indexT = 1;

        for (int i = 0; i < s.Length; i++) {
            if (!dictionaryS.ContainsKey(s[i])) {
                dictionaryS[s[i]] = indexS++;
            }
            if (!dictionaryT.ContainsKey(t[i])) {
                dictionaryT[t[i]] = indexT++;
            }
            if (dictionaryS[s[i]] != dictionaryT[t[i]]) {
                return false;
            }
        }

        return true;
    }
}