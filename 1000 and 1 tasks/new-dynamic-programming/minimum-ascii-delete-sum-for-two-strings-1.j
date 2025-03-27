import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


class Solution {

    private String s1;
    private String s2;
    private int F(int i, int j) {
        if (i == s1.length() && j == s2.length()) {
            return 0;
        }
        else if (i == s1.length()) {
            return s2.charAt(j) + F(i, j + 1);
        }
        else if (j == s2.length()) {
            return s1.charAt(i) + F(i + 1, j);
        }
        else if (s1.charAt(i) == s2.charAt(j)) {
            return F(i + 1, j + 1);
        }
        else {
            var option1 = s1.charAt(i) + F(i + 1, j);
            var option2 = s2.charAt(j) + F(i, j + 1);

            return Math.min(option1, option2);
        }
    }

    public int minimumDeleteSum(String s1, String s2) {
        this.s1 = s1;
        this.s2 = s2;

        return F(0, 0);
    }
}
