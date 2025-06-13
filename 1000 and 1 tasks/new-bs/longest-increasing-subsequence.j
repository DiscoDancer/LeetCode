import java.math.BigInteger;
import java.util.*;


class Solution {

    private int[] nums;
    private int result = 0;

    private void f(int i, int score, int max) {
        if (i == nums.length) {
            result = Math.max(result, score);
            return;
        }

        // skip
        f(i + 1, score, max);
        // take
        if (nums[i] > max) {
            f(i + 1, score + 1, nums[i]);
        }
    }

    public int lengthOfLIS(int[] nums) {
        this.nums = nums;

        f(0, 0, Integer.MIN_VALUE);

        return this.result;
    }
}
