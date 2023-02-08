public class Solution {
    public bool IsMonotonic(int[] nums) {
        if (nums.Length == 1) {
            return true;
        }

        var increasing = false;
        var decreasing = false;

        for (int i = 1; i < nums.Length; i++) {
            var increasingCur = nums[i-1] - nums[i] > 0;
            var decreasingCur = nums[i-1] - nums[i] < 0;

            if (!increasing && !decreasing) {
                if (increasingCur) {
                    increasing = true;
                }
                if (decreasingCur) {
                    decreasing = true;
                }
            }
            else {
                if (increasing && decreasingCur || decreasing && increasingCur) {
                    return false;
                }
            }
        }

        return true;
    }
}