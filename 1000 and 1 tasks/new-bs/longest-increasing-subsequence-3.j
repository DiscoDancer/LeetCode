import java.math.BigInteger;
import java.util.*;


class Solution {

    private int[] nums;

    private int f(int i, int maxI) {
        if (i == nums.length) {
            return 0;
        }

        var skip = f(i + 1, maxI);
        var take = 0;
        if (nums[i] > nums[maxI]) {
            take = 1 + f(i + 1, i);
        }

        return Math.max(take, skip);
    }

    public int lengthOfLIS(int[] nums) {
        var arr = new int[nums.length+1];
        for (int i = 0; i < nums.length; i++) {
            arr[i+1] = nums[i];
        }
        arr[0] = Integer.MIN_VALUE;
        this.nums = arr;

        return f(0, 0);
    }
}
