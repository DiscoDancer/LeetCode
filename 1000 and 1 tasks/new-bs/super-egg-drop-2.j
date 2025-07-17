import java.math.BigInteger;
import java.util.*;

// cheacting with chatgpt

class Solution {

    private int[][] table;

    private int findLocalMin(int k, int n) {
        var xl = 1;
        var xr = n;
        while (xl < xr) {
            var xm = xl + (xr - xl) / 2;
            if (table[k - 1][xm - 1] < table[k][n - xm]) {
                xl = xm + 1;
            } else {
                xr = xm;
            }
        }
        return xl;
    }

    public int superEggDrop(int k, int n) {
        table = new int[k + 1][n + 1];

        // if k == 1, no bs is available, so we need n attempts
        // типа мы все перебираем от начала и до конца
        for (var ni = 1; ni <= n; ni++) {
            table[1][ni] = ni;
        }

        for (var ki = 2; ki <= k; ki++) {
            for (var ni = 1; ni <= n; ni++) {
                // take prev - always an option
                // верхнего из нижнего можно получить за 1 бросок
                // по сути точно такое же код как с k = 1. Если нужно яйцо N, бросаем N раз
                table[ki][ni] = 1 + table[ki][ni-1];

                var x = findLocalMin(ki, ni);

//                var xl = 1;
//                var xr = ni;
//
//                while (xl <= xr) {
//                    var xm = xl + (xr - xl) / 2;
//                    var fxm = Math.max(table[ki-1][xm - 1], table[ki][ni - xm]);
//                    if (xm == xl)
//                }

                // consider to drop
                //for (var x = 1; x <= ni; x++) {
                    table[ki][ni] = Math.min(table[ki][ni], 1 + Math.max(table[ki-1][x - 1], table[ki][ni - x]));
                //}
            }
        }

        return table[k][n];
    }
}