import java.math.BigInteger;
import java.util.*;


class Solution {

    private int[] w;
    private int sum = 0;
    private int[] prefixSums;

    public Solution(int[] w) {
        this.w = w;
        this.prefixSums = new int[w.length];

        for (var i = 0; i < w.length; i++) {
            sum += w[i];
            if (i > 0) {
                prefixSums[i] = prefixSums[i - 1] + w[i];
            } else {
                prefixSums[i] = w[i];
            }
        }
    }

    public int pickIndex() {
        var rand = new Random();
        // both inclusive
        var max = sum-1;
        var min = 0;
        int randomNum = rand.nextInt((max - min) + 1) + min;

        // берем первое, которое больше случайного числа
        // либо 0й, либо предыдущий меньше

        var l = 0;
        var r = w.length - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;
            if (prefixSums[m] > randomNum && (m == 0 || prefixSums[m - 1] <= randomNum)) {
                return m;
            } else if (prefixSums[m] <= randomNum) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }
        
        return -42;
    }
}
