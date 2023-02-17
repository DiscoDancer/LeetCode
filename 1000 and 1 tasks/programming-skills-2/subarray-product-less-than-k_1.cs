// https://leetcode.com/problems/subarray-product-less-than-k/solutions/?envType=study-plan&id=programming-skills-ii&orderBy=most_votes
public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k) {
        if (k <= 1) {
            return 0;
        }

        var product = 1;
        var left = 0;
        var count = 0;
        for (int right = 0; right < nums.Length; right++) {
            product *= nums[right];
            while (product >= k) {
                product /= nums[left];
                left++;
            }
            count += right - left + 1;
        }

        return count;
    }
}