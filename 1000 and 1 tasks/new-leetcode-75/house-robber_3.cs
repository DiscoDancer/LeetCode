public class Solution {
    public int Rob(int[] nums) {
        var prev0 = 0;
        var prev1 = 0;

        for (int i = nums.Length - 1; i >= 0; i--) {
            var cur0 = prev1;
            var cur1 = Math.Max(prev0 + nums[i], prev1);

            prev0 = cur0;
            prev1 = cur1;
        }

        return Math.Max(prev0, prev1);
    }
}