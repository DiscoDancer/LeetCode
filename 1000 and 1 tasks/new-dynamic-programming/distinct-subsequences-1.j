import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


class Solution {

    private String s;
    private String t;

    private int F(int i, int j) {
        if (j == t.length()) {
            return 1;
        }
        if (i == s.length()) {
            return 0;
        }

        var optionTake = s.charAt(i) == t.charAt(j) ? F(i + 1, j + 1) : 0;
        var optionSkip = F(i + 1, j);

        return optionTake + optionSkip;
    }


    public int numDistinct(String s, String t) {
        this.s = s;
        this.t = t;

        return F(0, 0);
    }
}
