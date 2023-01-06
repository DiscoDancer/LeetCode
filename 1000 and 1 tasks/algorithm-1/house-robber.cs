public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1) {
            return nums[0];
        }
        if (nums.Length == 2) {
            return nums.Max();
        }

        var res = new int[nums.Length];
        res[0] = nums[0];
        res[1] = Math.Max(nums[1], nums[0]);

        for (int i = 2; i < nums.Length; i++) {
            res[i] = Math.Max(res[i-1], nums[i] + res[i-2]);
        }

        return res.Last();
    }
}