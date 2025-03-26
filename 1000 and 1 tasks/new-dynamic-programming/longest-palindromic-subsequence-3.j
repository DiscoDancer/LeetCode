import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {

//    private String s;
//    private Integer[][] memo;
//
//    private int F(int l, int r) {
//        if (memo[l][r] != null) {
//            return memo[l][r];
//        }
//        if (l > r) {
//            return 0;
//        }
//        if (l == r) {
//            return 1;
//        }
//
//        var max = 0;
//
//        // у нас 2 варианта, либо мы применяем, либо пропускаем левый
//
//        // фиксируем левый и пробуем подобрать к нему правый
//        // то есть применяем левый
//        var rx = r;
//        while (rx > l) {
//            if (s.charAt(rx) == s.charAt(l)) {
//                max = Math.max(max, F(l+1, rx - 1) + 2);
//                // нам не надо идти дальше, они там сами разберутся
//                break;
//            }
//            rx--;
//        }
//
//        // и еще их можно просто пропустить левый
//        max = Math.max(max, F(l + 1, r));
//
//        memo[l][r] = max;
//
//        return max;
//    }

    public int longestPalindromeSubseq(String s) {
//        this.s = s;
//
//        memo = new Integer[s.length()][s.length()];

        var table = new int[s.length() + 1][s.length() + 1];
        for (var l = s.length() - 1; l >= 0; l--) {
            for (var r = l; r <= s.length() - 1; r++) {
                if (l == r) {
                    table[l][r] = 1;
                    continue;
                }

                var max = 0;

                var rx = r;
                while (rx > l) {
                    if (s.charAt(rx) == s.charAt(l)) {
                        max = Math.max(max, table[l+1][rx-1] + 2);
                        break;
                    }
                    rx--;
                }

                // и еще их можно просто пропустить левый
                max = Math.max(max, table[l + 1][r]);

                table[l][r] = max;

                // return max;
            }
        }

        return table[0][s.length() - 1];
    }
}
