import java.util.*;

// TL

class Solution {

    private int[] nums;
    private int target;
    private int mod = 1000000007;
    private int result = 0;

    private void F(int i, int min, int max) {
        if (i == nums.length) {
            // must be not empty subsequence
            // given all nums[i] are positive
            if (min + max <= target && min > 0) {
                result++;
                result = result % mod;
            }
            return;
        }

        // decision: take or skip
        // take
        F(i + 1, min == 0 ? nums[i] : Math.min(min, nums[i]), Math.max(max, nums[i]));
        // skip
        F(i + 1, min, max);
    }

    public int numSubseq(int[] nums, int target) {
        this.nums = nums;
        this.target = target;

        F(0, 0, 0);

        return this.result;
    }
}
