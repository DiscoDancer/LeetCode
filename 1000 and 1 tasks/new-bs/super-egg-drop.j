import java.math.BigInteger;
import java.util.*;

// TL

class Solution {

    public int superEggDrop(int k, int n) {
        var table = new int[k + 1][n + 1];

        // if k == 1, no bs is available, so we need n attempts
        for (var ni = 1; ni <= n; ni++) {
            table[1][ni] = ni;
        }

        for (var ki = 2; ki <= k; ki++) {
            for (var ni = 1; ni <= n; ni++) {
                // base case
                if (ni <= 2) {
                    table[ki][ni] = ni;
                }
                else {
                    // take prev - always an option
                    table[ki][ni] = 1 + table[ki][ni-1];

                    // consider to drop
                    for (var x = 1; x <= ni; x++) {
                        var bottomHalfSize = x - 1;
                        var topHalfSize = ni - x;
                        table[ki][ni] = Math.min(table[ki][ni], 1 + Math.max(table[ki-1][bottomHalfSize], table[ki][topHalfSize]));
                    }
                }
            }
        }

        return table[k][n];
    }
}