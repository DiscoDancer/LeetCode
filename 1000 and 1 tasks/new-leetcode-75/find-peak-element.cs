public class Solution {
    public int FindPeakElement(int[] nums) {
        for (int i = 0; i < nums.Length; i++) {
            if (i == 0 && nums.Length > 1 && nums[i] > nums[i+1]) {
                return i;
            }
            if (i == nums.Length - 1 && nums.Length > 1 && nums[i-1] < nums[i]) {
                return i;
            }
            if (nums.Length > 2 && i > 0 && i < nums.Length - 1 && nums[i-1] < nums[i] && nums[i] > nums[i+1]) {
                return i;
            }
        }

        return 0;
    }
}