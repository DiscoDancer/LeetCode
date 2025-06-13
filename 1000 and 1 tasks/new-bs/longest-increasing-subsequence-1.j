import java.math.BigInteger;
import java.util.*;


class Solution {

    private int[] nums;

    private int f(int i, int max) {
        if (i == nums.length) {
            return 0;
        }

        var skip = f(i + 1, max);
        var take = 0;
        if (nums[i] > max) {
            take = 1 + f(i + 1, nums[i]);
        }

        return Math.max(take, skip);
    }

    public int lengthOfLIS(int[] nums) {
        this.nums = nums;

        return f(0, Integer.MIN_VALUE);
    }
}
