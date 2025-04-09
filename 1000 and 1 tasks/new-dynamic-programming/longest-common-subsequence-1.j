import java.util.*;


class Solution {
    private String text1;
    private String text2;

    private int F(int i, int j) {
        if (i == text1.length() || j == text2.length()) {
            return 0;
        }

        var take = 0;
        if (text1.charAt(i) == text2.charAt(j)) {
            take = 1 + F(i + 1, j + 1);
        }
        var skip1 = F(i + 1, j);
        var skip2 = F(i, j + 1);

        return Math.max(take, Math.max(skip1, skip2));
    }

    public int longestCommonSubsequence(String text1, String text2) {

        this.text1 = text1;
        this.text2 = text2;

        return F(0, 0);
    }
}