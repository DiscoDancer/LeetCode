public class Solution {
    public bool IsMonotonic(int[] nums) {
        var isDescresing = true;
        var isIncreasing = true;

        for (int i = 1; i < nums.Length && (isDescresing || isIncreasing); i++) {
            isDescresing &= nums[i] <= nums[i-1];
            isIncreasing &= nums[i] >= nums[i-1];
        }

        return isDescresing || isIncreasing;
    }
}