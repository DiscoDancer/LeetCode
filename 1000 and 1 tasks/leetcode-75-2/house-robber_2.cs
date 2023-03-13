public class Solution {
    // мое старое решение
    public int Rob(int[] nums) {
        if (nums.Length == 1) {
            return nums[0];
        }

        var prevPrev = nums[0];
        var prev = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++) {
            var cur = Math.Max(prev, prevPrev + nums[i]);
            prevPrev = prev;
            prev = cur;
        }

        return prev;
    }
}