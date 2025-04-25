import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    public int numDecodings(String s) {
        if (s.charAt(0) == '0') {
            return 0;
        }

        var table = new int[s.length() + 1];
        for (var i = s.length(); i >= 0; i--) {
            if (i == s.length()) {
                table[i] = 1;
            }
            else if (s.charAt(i) == '0') {
                table[i] = 0;
            }
            else {
                table[i] = table[i + 1];
                if (s.charAt(i) == '1' && i < s.length() - 1) {
                    table[i] += table[i + 2];
                }
                else if (s.charAt(i) == '2' && i < s.length() - 1 && s.charAt(i + 1) >= '0' && s.charAt(i + 1) <= '6') {
                    table[i] += table[i + 2];
                }
            }
        }

        return table[0];
    }
}
