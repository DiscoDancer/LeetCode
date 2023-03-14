public class Solution {
    // https://leetcode.com/problems/maximum-product-subarray/editorial/
    public int MaxProduct(int[] nums) {
        var min = nums[0];
        var max = nums[0];
        var result = max;

        for (int i = 1; i < nums.Length; i++) {
            var cur = nums[i];

            var newMax = Math.Max(cur, Math.Max(min * cur, max * cur));
            var newMin = Math.Min(cur, Math.Min(min * cur, max * cur));

            result = Math.Max(newMax, result);

            max = newMax;
            min = newMin;
        }

        return result;
    }
}