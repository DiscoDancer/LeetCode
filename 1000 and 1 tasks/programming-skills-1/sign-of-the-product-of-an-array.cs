public class Solution {
    public int ArraySign(int[] nums) {
        if (nums[0] == 0) {
            return 0;
        }

        var sign = nums[0] > 0;
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] == 0) {
                return 0;
            }
            if (nums[i] < 0) {
                sign = !sign;
            }
        }

        return sign ? 1 : -1;
    }
}