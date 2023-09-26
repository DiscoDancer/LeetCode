public class Solution {
    public bool IsAnagram(string s, string t) {
        var table = new int[26];

        foreach (var c in s) {
            table[c-'a']++;
        }

        foreach (var c in t) {
            table[c-'a']--;
        }

        for (int i = 0; i < 26; i++) {
            if (table[i] != 0) {
                return false;
            }
        }

        return true;
    }
}