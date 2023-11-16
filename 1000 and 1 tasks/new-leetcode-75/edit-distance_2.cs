public class Solution {
    // word1 -> word2
    public int MinDistance(string word1, string word2) {
        var table = new int[word1.Length + 1, word2.Length + 1];

        for (int i = 0; i <= word2.Length; i++) {
            table[word1.Length, i] = word2.Length - i;
        }
        for (int i = 0; i <= word1.Length; i++) {
            table[i, word2.Length] = word1.Length - i;
        }

        for (int i = word1.Length - 1; i >= 0; i--) {
            for (int j = word2.Length - 1; j >= 0; j--) {
                if (word1[i] == word2[j]) {
                    table[i,j] = table[i + 1, j + 1];
                }
                else {
                    var replace = table[i+1, j + 1] + 1;
                    var remove = table[i+1, j] + 1;
                    var insert = table[i, j + 1] + 1;


                    table[i,j] = Math.Min(replace, Math.Min(remove, insert));
                }
            }
        }

        return table[0,0];
    }
}