import java.util.*;


class Solution {

    private int max;
    private String text1;
    private String text2;

    private void F(int i, int j, int score) {
        if (i == text1.length() || j == text2.length()) {
            this.max = Math.max(this.max, score);
            return;
        }

        // take
        if (text1.charAt(i) == text2.charAt(j)) {
            F(i + 1, j + 1, score + 1);
        }
        F(i + 1, j, score); // skip 1
        F(i, j + 1, score); // skip 2
    }

    public int longestCommonSubsequence(String text1, String text2) {

        this.text1 = text1;
        this.text2 = text2;

        F(0, 0, 0);

        return this.max;
    }
}