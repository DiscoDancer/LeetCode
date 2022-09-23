public class Solution {
    public bool CanJump(int[] nums) {     
        var max = 0;
        
        for (int i = 0; i <= max; i++) {
            max = Math.Max(max, i + nums[i]);
            if (max >= nums.Length - 1) {
                return true;
            }
        }
        
        return false;
    }
}