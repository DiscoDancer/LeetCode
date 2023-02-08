public class Solution {
    public bool IsMonotonic(int[] nums) {
        var increasing = false;
        var decreasing = false;

        for (int i = 1; i < nums.Length; i++) {
            var increasingCur = nums[i-1] - nums[i] > 0;
            var decreasingCur = nums[i-1] - nums[i] < 0;

            if (!increasing && !decreasing) {
                increasing = increasingCur;
                decreasing = decreasingCur;
            }
            else if (increasing && decreasingCur || decreasing && increasingCur) {
                return false;
            }
        }

        return true;
    }
}