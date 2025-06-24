import java.math.BigInteger;
import java.util.*;


// TL, no array in state f

class Solution {

    private int[] nums;
    private int k;
    private int min = Integer.MAX_VALUE;

    // dp
    private void f(int i, int marker, int currentMarkerSum, int globalResult) {
        if (i == nums.length) {
            globalResult = Math.max(globalResult, currentMarkerSum);
            min = Math.min(min, globalResult);
            return;
        }

        currentMarkerSum += nums[i];

        // decision: change marker or not

        var rightCount = nums.length - (i+1);
        var markersLeft = k - marker;
        // not change marker
        if (rightCount >= markersLeft) {
            f(i+1, marker, currentMarkerSum, globalResult);
        }
        if (marker < k) {
            // change marker
            f(i+1, marker + 1, 0, Math.max(globalResult, currentMarkerSum));
        }
    }

    public int splitArray(int[] nums, int k) {
        this.nums = nums;
        this.k = k;

        f(0, 1, 0, Integer.MIN_VALUE);

        return this.min;
    }
}