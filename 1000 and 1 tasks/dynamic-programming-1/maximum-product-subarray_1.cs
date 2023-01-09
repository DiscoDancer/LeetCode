public class Solution {
    // https://leetcode.com/problems/maximum-product-subarray/solutions/738529/maximum-product-subarray/?envType=study-plan&id=dynamic-programming-i&orderBy=most_votes
    public int MaxProduct(int[] nums) {
        int max_so_far = nums[0];
        int min_so_far = nums[0];
        int result = max_so_far;

        for (int i = 1; i < nums.Length; i++) {
            int curr = nums[i];
            int temp_max = Math.Max(curr, Math.Max(max_so_far * curr, min_so_far * curr));
            min_so_far = Math.Min(curr, Math.Min(max_so_far * curr, min_so_far * curr));
            max_so_far = temp_max;
            result = Math.Max(max_so_far, result);
        }

        return result;
    }
}