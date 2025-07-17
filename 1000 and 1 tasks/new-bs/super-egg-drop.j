import java.math.BigInteger;
import java.util.*;

// TL

class Solution {

    public int superEggDrop(int k, int n) {
        var table = new int[k + 1][n + 1];

        // if k == 1, no bs is available, so we need n attempts
        // типа мы все перебираем от начала и до конца
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
                    // верхнего из нижнего можно получить за 1 бросок
                    // по сути точно такое же код как с k = 1. Если нужно яйцо N, бросаем N раз
                    table[ki][ni] = 1 + table[ki][ni-1];

                    // consider to drop
                    for (var x = 1; x <= ni; x++) {
                        // снизу от кинутого яйца
                        // k - 1 так как яйцо разбилось. Так как оно разбилось, поэтому мы идем вниз.
                        // Если бы не разбилось, то мы бы шли вверх
                        var bottomHalfSize = x - 1;
                        // сверху от кинутого яйца
                        // не разбилось, k не меняется
                        var topHalfSize = ni - x;
                        table[ki][ni] = Math.min(table[ki][ni], 1 + Math.max(table[ki-1][bottomHalfSize], table[ki][topHalfSize]));
                    }
                }
            }
        }

        return table[k][n];
    }
}