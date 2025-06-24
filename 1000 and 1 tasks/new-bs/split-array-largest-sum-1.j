import java.math.BigInteger;
import java.util.*;


// TL
// Важно, что условия построения гарантирует нам processResult валидный результат

class Solution {

    private int[] nums;
    private int k;

    private int min = Integer.MAX_VALUE;

    private void processResult(int[] marking) {
        var table = new int[k+1];
        for (int i = 0; i < marking.length; i++) {
            table[marking[i]] += nums[i];
        }

        var localMax = Integer.MIN_VALUE;
        for (var i = 1; i <= k; i++) {
            localMax = Math.max(localMax, table[i]);
        }

        min = Math.min(min, localMax);

        var stop = true;
    }

    // dp + backtracking
    private void f(int i, int marker, int[] marking) {
        if (i == nums.length) {
            processResult(marking);
            return;
        }

        marking[i] = marker;
        // decision: change marker or not

        var rightCount = nums.length - (i+1);
        var markersLeft = k - marker;
        // not change marker
        if (rightCount >= markersLeft) {
            f(i+1, marker, marking.clone());
        }
        if (marker < k) {
            // change marker
            f(i+1, marker + 1, marking.clone());
        }
    }

    public int splitArray(int[] nums, int k) {
        this.nums = nums;
        this.k = k;

        var state = new int[nums.length];
        f(0, 1, state);


        return this.min;
    }
}