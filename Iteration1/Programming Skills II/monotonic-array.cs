public class Solution {
    public bool IsMonotonic(int[] nums) {
        var allInc = true;
        var allDec = true;
        for (int i = 0; i < nums.Length - 1 && (allInc || allDec); i++) {
            if (nums[i] < nums[i + 1]) {
                allDec = false;
            } else if (nums[i] > nums[i + 1]) {
                allInc = false;
            }
        }
        
        return allInc || allDec;
    }
}