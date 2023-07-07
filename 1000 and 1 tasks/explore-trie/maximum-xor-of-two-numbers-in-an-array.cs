public class Solution {
    public int FindMaximumXOR(int[] nums) {
        var max = 0;

        for (int i = 0; i < nums.Length; i ++) {
            for (int j = i+1; j < nums.Length; j++) {
                max = Math.Max(nums[i] ^ nums[j], max);
            }
        }

        return max;
    }
}