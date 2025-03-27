import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


class Solution {

    public int minimumDeleteSum(String s1, String s2) {
        var table = new int[s1.length() + 1][s2.length() + 1];

        for (var i = s1.length(); i >= 0; i--) {
            for (var j = s2.length(); j >= 0; j--) {
                if (i == s1.length() && j == s2.length()) {
                    table[i][j] = 0;
                } else if (i == s1.length()) {
                    table[i][j] = s2.charAt(j) + table[i][j + 1];
                } else if (j == s2.length()) {
                    table[i][j] = s1.charAt(i) + table[i + 1][j];
                } else if (s1.charAt(i) == s2.charAt(j)) {
                    table[i][j] = table[i + 1][j + 1];
                } else {
                    var option1 = s1.charAt(i) + table[i + 1][j];
                    var option2 = s2.charAt(j) + table[i][j + 1];

                    table[i][j] = Math.min(option1, option2);
                }
            }
        }

        return table[0][0];
    }
}
