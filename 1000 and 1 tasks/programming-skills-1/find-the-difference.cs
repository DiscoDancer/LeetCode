public class Solution {
    public char FindTheDifference(string s, string t) {
        const int tableSize = 26;
        var table = new int[tableSize];

        foreach (var c in t) {
            table[c - 'a']++;
        }

        foreach (var c in s) {
            table[c - 'a']--;
        }

        for (int i = 0; i < tableSize; i++) {
            if (table[i] > 0) {
                return (char) (i + (int)'a');
            }
        }

        return 'a';
    }
}