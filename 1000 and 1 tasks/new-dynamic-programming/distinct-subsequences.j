import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

// TL


class Solution {

    private String s;
    private String t;
    private int count = 0;

    private void F(int i, int j) {
        if (j == t.length()) {
            count++;
            return;
        }
        if (i == s.length()) {
            return;
        }

        if (s.charAt(i) == t.charAt(j)) {
            F(i + 1, j + 1);
        }
        F(i + 1, j);
    }


    public int numDistinct(String s, String t) {
        this.s = s;
        this.t = t;

        F(0, 0);

        return this.count;
    }
}
