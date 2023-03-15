public class Solution {
    private bool IsValid(string s, string t) {
        var tableLower = new int[26];
        var tableUpper = new int[26];

        foreach (var c in s) {
            if (Char.IsUpper(c)) {
                tableUpper[c - 'A']++;
            }
            else {
                tableLower[c - 'a']++;
            }
        }

        foreach (var c in t) {
            if (Char.IsUpper(c)) {
                tableUpper[c - 'A']--;
                if (tableUpper[c - 'A'] < 0) {
                    return false;
                }
            }
            else {
                tableLower[c - 'a']--;
                if (tableLower[c - 'a'] < 0) {
                    return false;
                }
            }
        }

        return true;
    }

    public string MinWindow(string s, string t) {
        var length = t.Length;
        while (length <= s.Length) {
            var possibleStartCount = s.Length - length + 1;
            for (int i = 0; i < possibleStartCount; i++) {
                var sub = s.Substring(i, length);
                if (IsValid(sub, t)) {
                    return sub;
                }
            }
            length++;
        }

        return "";
    }
}