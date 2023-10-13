public class Solution {
    // проверить длину, проверить те же символы
    // те же частоты
    public bool CloseStrings(string word1, string word2) {
        var table1 = new int[26];
        var table2 = new int[26];

        foreach (var c in word1) {
            table1[c-'a']++;
        }
        foreach (var c in word2) {
            table2[c-'a']++;
        }

        for (int i = 0; i < 26; i++) {
            if (table1[i] != 0  && table2[i] == 0 || table1[i] == 0  && table2[i] != 0) {
                return false;
            }
        }

        Array.Sort(table1);
        Array.Sort(table2);

        for (int i = 0; i < 26; i++) {
            if (table1[i] != table2[i]) {
                return false;
            }
        }

        return true;
    }
}