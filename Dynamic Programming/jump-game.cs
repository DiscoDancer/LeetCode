public class Solution {
    public bool CanJump(int[] nums) {
        if (nums.Length == 1) {
            return true;
        }
        
        var statuses = new bool[nums.Length];
        
        for (int i = 0; i < nums.Length && !statuses[nums.Length - 1]; i++) {
            if (i == 0 || statuses[i]) {
                for (int j = i + 1; j < i + 1 + nums[i] && j < nums.Length; j++) {
                    if (!statuses[j]) {
                        statuses[j] = true;
                    }
                }
            }
        }
        
        return statuses[nums.Length - 1];
    }
}