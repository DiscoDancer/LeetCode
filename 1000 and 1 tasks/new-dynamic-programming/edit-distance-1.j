import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


class Solution {


    private String word1;
    private String word2;

    private int F(int i, int j) {
        if (i == word1.length() && j == word2.length()) {
            return 0;
        }
        // if the first word is out, then insert
        else if (i == word1.length()) {
            return 1 + F(i, j + 1);
        }
        // if the second word is out, then delete
        else if (j == word2.length()) {
            return 1 + F(i + 1, j);
        }
        else if (word1.charAt(i) == word2.charAt(j)) {
            return F(i + 1, j + 1);
        }
        else {
            // insert
            var insert = 1 + F(i, j + 1);
            // delete
            var delete = 1 + F(i + 1, j);
            // replace
            var replace = 1 + F(i + 1, j + 1);

            return Math.min(Math.min(insert, delete), replace);
        }
    }

    public int minDistance(String word1, String word2) {

        this.word1 = word1;
        this.word2 = word2;

        return F(0, 0);
    }
}
