public class Solution {
    private string _s;
    private string _t;
    private int[] _tLowerTable = new int[26];
    private int[] _tUpperTable = new int[26];

    private void FillTTables() {
        foreach (var c in _t) {
            if (Char.IsUpper(c)) {
                _tUpperTable[c - 'A']++;
            }
            else {
                _tLowerTable[c - 'a']++;
            }
        }
    }

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

        for (int i = 0; i < 26; i++) {
            if (!(tableUpper[i] >= _tUpperTable[i] && tableLower[i] >= _tLowerTable[i])) {
                return false;
            }
        }

        return true;
    }

    /*
        Идеи:
        + не брать подстроки
        - смещать s
        + посчитать t только 1 раз
        + сравнивать таблицы 0..25
    */

    public string MinWindow(string s, string t) {
        _s = s;
        _t = t;
        FillTTables();

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