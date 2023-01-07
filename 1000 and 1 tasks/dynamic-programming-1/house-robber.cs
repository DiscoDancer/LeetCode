public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1) {
            return nums[0];
        }

        var res = new int[nums.Length];
        res[0] = nums[0];
        res[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++) {
            res[i] = Math.Max(res[i-1], res[i-2] + nums[i]);
        }

        return res.Last();
    }
}