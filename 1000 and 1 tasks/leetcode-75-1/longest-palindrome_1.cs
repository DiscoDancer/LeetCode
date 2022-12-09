public class Solution {
    // количество пар * 2 + 1 если есть хоть одна не пара
    public int LongestPalindrome(string s) {
        const int Size = 26;
        var lowerTable = new int[Size];
        var upperTable = new int[Size];

        foreach (var c in s) {
            if (Char.IsLower(c)) {
                lowerTable[c - 'a']++;
            }
            else {
                upperTable[c - 'A']++;
            }
        }

        var res = 0;

        var hasAnySingle = false;
        for (int i = 0; i < Size; i++) {
            if (lowerTable[i] > 0) {
                res += (lowerTable[i] / 2) * 2;
            }
            if (upperTable[i] > 0) {
                res += (upperTable[i] /2 ) * 2;
            }
            if (!hasAnySingle && (upperTable[i] % 2 == 1 || lowerTable[i] % 2 == 1)) {
                hasAnySingle = true;
            }
        }

        if (hasAnySingle) {
            res++;
        }

        return res;
    }
}