public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1) {
            return nums[0];
        }
        if (nums.Length == 2) {
            return nums.Max();
        }

        var prevPrev = nums[0];
        var prev = Math.Max(nums[1], nums[0]);

        for (int i = 2; i < nums.Length; i++) {
            var cur = Math.Max(prev, nums[i] + prevPrev);
            prevPrev = prev;
            prev = cur;
        }

        return prev;
    }
}