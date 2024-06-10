public class Solution {
    public bool CanJump(int[] nums) {
        var maxCanReach = 0;
        for (var i = 0; i < nums.Length && i <= maxCanReach; i++) {
            maxCanReach = Math.Max(i + nums[i], maxCanReach);
        }

        return maxCanReach >= nums.Length - 1;
    }
}