public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length < 3) {
            return nums.Max();
        }

        var a = nums[0];
        var b = Math.Max(nums[0], nums[1]);

        for (int i=2; i < nums.Length; i++) {
            var c = Math.Max(b, a + nums[i]);
            a = b;
            b = c;
        }

        return b;
    }
}