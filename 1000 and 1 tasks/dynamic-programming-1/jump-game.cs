public class Solution {
    // для последующих считаем запас
    public bool CanJump(int[] nums) {
        if (nums.Length == 1) {
            return true;
        }

        var prev = nums[0];

        for (int i = 1; i < nums.Length; i++) {
            if (prev < 1) {
                return false;
            }
            var cur = Math.Max(prev - 1, nums[i]);
            prev = cur;
        }

        return true;
    }
}