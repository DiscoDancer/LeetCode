import java.math.BigInteger;
import java.util.*;

// see koko-eating-bananas

class Solution {

    private int[] dist;
    private double hour;

    private boolean F(int speed) {
        double sum = 0.0;
        for (int x : dist) {
            // if need to wait, then round up
            if (Math.ceil(sum) != sum) {
                sum = Math.ceil(sum);
            }
            sum += (double) x / speed;
        }
        return sum <= hour;
    }


    public int minSpeedOnTime(int[] dist, double hour) {
        this.dist = dist;
        this.hour = hour;


        // [1,1,100000] + 2.01 -> 10000000
        var max = Arrays.stream(dist).max().orElse(0)*100;
        var min = 1;

        var l = min;
        var r = max;

        while (l <= r) {
            var m = l + (r - l) / 2;
            if (F(m) && (m == 0 || !F(m - 1))) {
                return m;
            } else if (F(m)) {
                r = m - 1;
            } else {
                l = m + 1;
            }
        }

        return -1;
    }
}