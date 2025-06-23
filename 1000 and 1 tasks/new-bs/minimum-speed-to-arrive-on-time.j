import java.math.BigInteger;
import java.util.*;

// TL

class Solution {

    public int minSpeedOnTime(int[] dist, double hour) {
        // [1,1,100000] + 2.01 -> 10000000
        var max = Arrays.stream(dist).max().orElse(0)*100;
        var min = 1;

        for (int speed = min; speed <= max; speed++) {
            var sum = 0.0;
            for (var x : dist) {
                // if need to wait, then round up
                if (Math.ceil(sum) != sum) {
                    sum = Math.ceil(sum);
                }
                sum += (double) x / speed;
            }
            if (sum <= hour) {
                return speed;
            }
        }

        return -1;
    }
}