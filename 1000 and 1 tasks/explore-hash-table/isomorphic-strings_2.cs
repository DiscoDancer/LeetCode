public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        const int ASCII_SIZE = 128;
        var dictionaryS = new int[ASCII_SIZE];
        var indexS = 1;
        var dictionaryT = new int[ASCII_SIZE];
        var indexT = 1;

        for (int i = 0; i < s.Length; i++) {
            if (dictionaryS[s[i]] == 0) {
                dictionaryS[s[i]] = indexS++;
            }
            if (dictionaryT[t[i]] == 0) {
                dictionaryT[t[i]] = indexT++;
            }
            if (dictionaryS[s[i]] != dictionaryT[t[i]]) {
                return false;
            }
        }

        return true;
    }
}