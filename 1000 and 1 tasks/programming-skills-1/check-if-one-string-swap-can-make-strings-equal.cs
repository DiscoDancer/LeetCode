public class Solution {
    public bool AreAlmostEqual(string s1, string s2) {
        const int tableSize = 26;
        var table = new int[tableSize];
        var countSame = 0;

        for (int i = 0; i < s1.Length; i++) {
            table[s1[i] - 'a']++;
            table[s2[i] - 'a']--;
            if (s1[i] == s2[i]) {
                countSame++;
            }
        }

        for (int i = 0; i < tableSize; i++) {
            if (table[i] != 0) {
                return false;
            }
        }

        return countSame == s1.Length || countSame == s1.Length - 2;
    }
}