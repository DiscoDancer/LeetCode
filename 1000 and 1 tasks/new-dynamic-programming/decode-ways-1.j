import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    private String s;

    private int F(int i) {
        if (i >= s.length()) {
            return 1;
        }

        var result = 0;

        // one option case (no ambiguity)
        if (s.charAt(i) >= '3' && s.charAt(i) <= '9') {
            result += F(i + 1);
        }
        else if (s.charAt(i) == '2' || s.charAt(i) == '1') {
            // take 1
            result +=F(i + 1);
            // take 2
            if (s.charAt(i) == '1' && i < s.length() - 1) {
                result += F(i + 2);
            }
            // take 2
            if (s.charAt(i) == '2' && i < s.length() - 1 && s.charAt(i + 1) >= '0' && s.charAt(i + 1) <= '6') {
                result +=F(i + 2);
            }
        }
        else if (s.charAt(i) == '0') {
            // dead end
        }

        return result;
    }

    public int numDecodings(String s) {
        if (s.charAt(0) == '0') {
            return 0;
        }

        this.s = s;

        return F(0);
    }
}
