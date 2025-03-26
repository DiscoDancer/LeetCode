import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {

    public int longestPalindromeSubseq(String s) {
        var table = new int[s.length() + 1][s.length() + 1];
        for (var l = s.length() - 1; l >= 0; l--) {
            for (var r = l; r <= s.length() - 1; r++) {
                if (l == r) {
                    table[l][r] = 1;
                    continue;
                }

                var rx = r;
                while (rx > l) {
                    if (s.charAt(rx) == s.charAt(l)) {
                        // нам не надо идти дальше, они там сами разберутся
                        table[l][r] = table[l+1][rx-1] + 2;
                        break;
                    }
                    rx--;
                }

                // и еще их можно просто пропустить левый
                table[l][r] = Math.max(table[l][r], table[l + 1][r]);
            }
        }

        return table[0][s.length() - 1];
    }
}
