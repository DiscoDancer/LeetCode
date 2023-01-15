public class Solution {

    private int LengthOfLISInner(int[] nums, int curIndex, int curMax, int acc) {
        if (curIndex >= nums.Length ) {
            return acc;
        }

        int include = 0;
        int exclude = 0;

        if (curMax == -1 || nums[curIndex] > curMax) {
            include = LengthOfLISInner(nums, curIndex + 1, nums[curIndex], acc + 1);
        }

        // не берем текущий
        exclude = LengthOfLISInner(nums, curIndex + 1, curMax, acc);

        return Math.Max(include, exclude);
    }

    public int LengthOfLIS(int[] nums) {
        return LengthOfLISInner(nums, 0, -1, 0);
    }
}