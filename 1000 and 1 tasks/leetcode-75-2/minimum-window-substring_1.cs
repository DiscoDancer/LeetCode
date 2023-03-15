public class Solution {
    private string _s;
    private string _t;

    private bool IsValid(int startIndex, int length) {
        var tableLower = new int[26];
        var tableUpper = new int[26];

        for (int i = 0; i < length; i++) {
            var c = _s[i + startIndex];
            if (Char.IsUpper(c)) {
                tableUpper[c - 'A']++;
            }
            else {
                tableLower[c - 'a']++;
            }
        }

        foreach (var c in _t) {
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

    /*
        Идеи:
        + не брать подстроки
        - смещать s
        - посчитать t только 1 раз
        - сравнивать таблицы 0..25
    */

    // TL
    public string MinWindow(string s, string t) {
        _s = s;
        _t = t;

        var length = t.Length;
        while (length <= s.Length) {
            var possibleStartCount = s.Length - length + 1;
            for (int i = 0; i < possibleStartCount; i++) {
                if (IsValid(i, length)) {
                    return s.Substring(i, length);;
                }
            }
            length++;
        }

        return "";
    }
}