import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


class Solution {
    public int numDistinct(String s, String t) {
        var table = new int[s.length() + 1][t.length() + 1];


        for (int i = s.length(); i >= 0; i--) {
            for (int j = t.length(); j >= 0; j--) {
                if (j == t.length()) {
                    table[i][j] = 1;
                } else if (i == s.length()) {
                    table[i][j] = 0;
                } else {
                    var optionTake = s.charAt(i) == t.charAt(j) ? table[i + 1][j + 1] : 0;
                    var optionSkip = table[i + 1][j];

                    table[i][j] = optionTake + optionSkip;
                }
            }
        }

        return table[0][0];
    }
}
