public class Solution {
    // больше звучит как dp
    public bool CanJump(int[] nums) {
        var maxDistance = 0;
        var i = 0;
        for (; i < nums.Length && (i == 0 || maxDistance >= i); i++) {
            maxDistance = Math.Max(maxDistance, i + nums[i]);
        }

        return i == nums.Length;
    }
}