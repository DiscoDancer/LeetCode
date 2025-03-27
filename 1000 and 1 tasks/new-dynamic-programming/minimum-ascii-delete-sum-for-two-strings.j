import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


class Solution {

    private String s1;
    private String s2;
    private int min = Integer.MAX_VALUE;

    private void F(int i, int j, int score) {
        if (i == s1.length() && j == s2.length()) {
            min = Math.min(min, score);
            return;
        }
        else if (i == s1.length()) {
            F(i, j + 1, score + s2.charAt(j));
        }
        else if (j == s2.length()) {
            F(i + 1, j, score + s1.charAt(i));
        }
        else if (s1.charAt(i) == s2.charAt(j)) {
            F(i + 1, j + 1, score);
        }
        else {
            F(i + 1, j, score + s1.charAt(i));
            F(i, j + 1, score + s2.charAt(j));
        }
    }

    public int minimumDeleteSum(String s1, String s2) {
        this.s1 = s1;
        this.s2 = s2;

        F(0, 0, 0);

        return this.min;
    }
}
