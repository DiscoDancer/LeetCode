import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    private String s;
    private int count = 0;

    private void F(int i) {
        if (i >= s.length()) {
            count++;
            return;
        }

        // one option case (no ambiguity)
        if (s.charAt(i) >= '3' && s.charAt(i) <= '9') {
            F(i + 1);
        }
        else if (s.charAt(i) == '2' || s.charAt(i) == '1') {
            // take 1
            F(i + 1);
            // take 2
            if (s.charAt(i) == '1' && i < s.length() - 1) {
                F(i + 2);
            }
            // take 2
            if (s.charAt(i) == '2' && i < s.length() - 1 && s.charAt(i + 1) >= '0' && s.charAt(i + 1) <= '6') {
                F(i + 2);
            }
        }
        else if (s.charAt(i) == '0') {
            // dead end
            return;
        }
    }

    public int numDecodings(String s) {
        if (s.charAt(0) == '0') {
            return 0;
        }

        this.s = s;
        
        F(0);

        return this.count;
    }
}
