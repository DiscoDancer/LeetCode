public class Solution {
    // o(n), but log required
    public int FindPeakElement(int[] nums) {
        for (int i = 0; i < nums.Length; i++) {
            if (i == 0) {
                if (nums.Length > 1 && nums[0] > nums[1] || nums.Length == 1) {
                    return 0;
                }
            }
            else if (i == nums.Length - 1) {
                if (nums[i] > nums[i-1]) {
                    return i;
                }
            }
            else if (nums.Length > 2) {
                if (nums[i] > nums[i-1] && nums[i] > nums[i+1]) {
                    return i;
                }
            }
        }

        return -1;
    }
}