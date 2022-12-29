public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        const int TableSize = 26;
        var table = new int[TableSize];

        foreach (var c in s) {
            table[c - 'a']++;
        }
        foreach (var c in t) {
            table[c - 'a']--;
        }

        for (int i = 0; i < TableSize; i++) {
            if (table[i] != 0) {
                return false;
            }
        }

        return true;
    }
}