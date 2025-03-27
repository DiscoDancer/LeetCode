import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


class Solution {


    private String word1;
    private String word2;

    private int min = Integer.MAX_VALUE;

    private void F(int i, int j, int score) {
        if (i == word1.length() && j == word2.length()) {
            min = Math.min(min, score);
            return;
        }
        // if the first word is out, then insert
        else if (i == word1.length()) {
            F(i, j + 1, score + 1);
            return;
        }
        // if the second word is out, then delete
        else if (j == word2.length()) {
            F(i + 1, j, score + 1);
            return;
        }
        else if (word1.charAt(i) == word2.charAt(j)) {
            F(i + 1, j + 1, score);
        }
        else {
            // insert
            F(i, j + 1, score + 1);
            // delete
            F(i + 1, j, score + 1);
            // replace
            F(i + 1, j + 1, score + 1);
        }
    }

    public int minDistance(String word1, String word2) {

        this.word1 = word1;
        this.word2 = word2;

        F(0, 0, 0);

        return this.min;
    }
}
