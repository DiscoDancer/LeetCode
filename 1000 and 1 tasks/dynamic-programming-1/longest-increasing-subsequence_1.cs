public class Solution {

    // Time limit
    private int LengthOfLISInner(int[] nums, int curIndex, int curMax, int acc) {
        if (curIndex >= nums.Length) {
            return acc;
        }

        // берем текущий
        int include;
        if (curMax == -1) {
            include = LengthOfLISInner(nums, curIndex + 1, nums[curIndex], 1);
        } else if (nums[curIndex] > curMax) {
            include = LengthOfLISInner(nums, curIndex + 1, nums[curIndex], acc + 1);
        } else {
            include = LengthOfLISInner(nums, curIndex + 1, curMax, acc);
        }

        int exclude = LengthOfLISInner(nums, curIndex + 1, curMax, acc);

        return Math.Max(include, exclude);

    }

    public int LengthOfLIS(int[] nums) {
        return LengthOfLISInner(nums, 0, -1, 0);
    }
}