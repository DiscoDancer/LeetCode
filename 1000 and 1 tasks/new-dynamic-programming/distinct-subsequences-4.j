import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


class Solution {
    public int numDistinct(String s, String t) {
        var line = new int[t.length() + 1];

        var prev = 0;
        var prevPrev = 0;


        for (int i = s.length(); i >= 0; i--) {
            for (int j = t.length(); j >= 0; j--) {
                prev = line[j];
                if (j == t.length()) {
                    line[j] = 1;
                } else if (i == s.length()) {
                    line[j] = 0;
                } else {
                    var optionTake = s.charAt(i) == t.charAt(j) ? prevPrev : 0;
                    var optionSkip = prev;

                    line[j] = optionTake + optionSkip;
                }
                prevPrev = prev;
            }
        }

        return line[0];
    }
}
