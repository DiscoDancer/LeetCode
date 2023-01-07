public class Solution {

    public int RobInner(int[] nums, int start, int end) {
        if (nums.Length == 1) {
            return nums[0];
        }

        var prevPrev = nums[start];
        var prev = Math.Max(nums[start], nums[++start]);

        for (int i = start + 1; i <= end; i++) {
            var cur = Math.Max(prev, prevPrev + nums[i]);
            prevPrev = prev;
            prev = cur;
        }

        return prev;
    }

    public int Rob(int[] nums) {
        if (nums.Length < 3) {
            return nums.Max();
        }

        var r1 = RobInner(nums, 0, nums.Length - 2);
        var r2 = RobInner(nums, 1, nums.Length - 1);

        return Math.Max(r1, r2);
    }
}