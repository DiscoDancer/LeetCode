import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

class Solution {

    private final List<String> result = new LinkedList<>();
    private Character[][] table;
    private String digits;

    // i-th needs to be processed
    private void F(int i, StringBuilder sb) {
        if (i == digits.length()) {
            result.add(sb.toString());
            return;
        }

        var currentDigit = digits.charAt(i) - '0';
        var currentLetters = table[currentDigit];
        for (var c: currentLetters) {
            var l = sb.length();
            sb.append(c);
            F(i + 1, sb);
            sb.deleteCharAt(l);
        }
    }

    public List<String> letterCombinations(String digits) {
        if (digits.isEmpty()) {
            return new ArrayList<>();
        }
        this.table = new Character[][]{
                {}, // sentinel 0
                {}, // sentinel 1
                {'a', 'b', 'c'},
                {'d', 'e', 'f'},
                {'g', 'h', 'i'},
                {'j', 'k', 'l'},
                {'m', 'n', 'o'},
                {'p', 'q', 'r', 's'},
                {'t', 'u', 'v'},
                {'w', 'x', 'y', 'z'}
        };
        this.digits = digits;
        F(0, new StringBuilder());
        return result;
    }
}