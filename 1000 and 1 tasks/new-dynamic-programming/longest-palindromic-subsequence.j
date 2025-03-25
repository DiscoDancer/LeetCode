import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {

    private String s;
    private Integer[][] memo;

    private int F(int l, int r) {
        if (memo[l][r] != null) {
            return memo[l][r];
        }
        if (l > r) {
            return 0;
        }
        if (l == r) {
            return 1;
        }

        var max = 0;

        // фиксируем левый и пробуем подобрать к нему правый
        var rx = r;
        while (rx > l) {
            if (s.charAt(rx) == s.charAt(l)) {
                max = Math.max(max, F(l+1, rx - 1) + 2);
                // F(l + 1, rx - 1, score + 2);
                // нам не надо идти дальше, они там сами разберутся
                break;
            }
            rx--;
        }

        // фиксируем правый и пробуем подобрать к нему левый
        var lx = l;
        while (lx < r) {
            if (s.charAt(lx) == s.charAt(r)) {
                max = Math.max(max, F(lx + 1, r - 1) + 2);
                // F(lx + 1, r - 1, score + 2);
                // нам не надо идти дальше, они там сами разберутся
                break;
            }
            lx++;
        }

        // и еще их можно просто пропустить
        max = Math.max(max, F(l + 1, r));
        max = Math.max(max, F(l, r - 1));
        // F(l + 1, r, score);
        // F(l, r - 1, score);

        memo[l][r] = max;
        
        return max;
    }

    public int longestPalindromeSubseq(String s) {
        this.s = s;

        memo = new Integer[s.length()][s.length()];

        return F(0, s.length() - 1);

        // return max;
    }
}
