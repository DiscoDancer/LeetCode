public class Solution {
    // n^3
    public int LargestPerimeter(int[] nums) {
        var max = 0;

        for (int i = 0; i < nums.Length; i++) {
            for (int j = i+1; j < nums.Length; j++) {
                for (int k = j+1; k < nums.Length; k++) {
                    if (nums[i] < nums[j] + nums[k] && nums[j] < nums[i] + nums[k] &&
                    nums[k] < nums[j] + nums[i]) {
                        max = Math.Max(max, nums[i] + nums[j] + nums[k]);
                    }
                }
            }
        }

        return max;
    }
}