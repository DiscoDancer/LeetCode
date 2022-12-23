public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        var table = new int[26];

        foreach (var c in s) {
            table[c - 'a']++;
        }

        foreach (var c in t) {
            var charToInt = c - 'a';
            table[charToInt]--;
            if (table[charToInt] < 0) {
                return false;
            }
        }

        return true;
    }
}