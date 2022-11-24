public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int minIndex = -1;
        int maxIndex = -1;
        
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == target) {
                if (minIndex < 0) {
                    minIndex = i;
                }
                
                maxIndex = Math.Max(maxIndex, i);
            }
        }
        
        return new int[] {minIndex, maxIndex};
        
    }
}