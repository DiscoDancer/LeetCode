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


        for (var i = 0; i < w.length; i++) {
            if (randomNum < prefixSums[i]) {
                return i;
            }
        }

        return -42;
    }
}
