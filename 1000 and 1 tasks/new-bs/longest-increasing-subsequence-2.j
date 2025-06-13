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
        if (maxI == -1 || nums[i] > nums[maxI]) {
            take = 1 + f(i + 1, i);
        }

        return Math.max(take, skip);
    }

    public int lengthOfLIS(int[] nums) {
        this.nums = nums;

        return f(0, -1);
    }
}
