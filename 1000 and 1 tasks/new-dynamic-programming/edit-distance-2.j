import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


class Solution {
    public int minDistance(String word1, String word2) {
        var table = new int[word1.length() + 1][word2.length() + 1];

        for (int i = word1.length(); i >= 0; i--) {
            for (int j = word2.length(); j >= 0; j--) {
                if (i == word1.length() && j == word2.length()) {
                    table[i][j] = 0;
                }
                // if the first word is out, then insert
                else if (i == word1.length()) {
                    table[i][j] = 1 + table[i][j + 1];
                }
                // if the second word is out, then delete
                else if (j == word2.length()) {
                    table[i][j] = 1 + table[i + 1][j];
                } else if (word1.charAt(i) == word2.charAt(j)) {
                    table[i][j] = table[i + 1][j + 1];
                } else {
                    // insert
                    var insert = 1 + table[i][j + 1];
                    // delete
                    var delete = 1 + table[i + 1][j];
                    // replace
                    var replace = 1 + table[i + 1][j + 1];

                    table[i][j] =  Math.min(Math.min(insert, delete), replace);
                }
            }
        }

        return table[0][0];
    }
}
