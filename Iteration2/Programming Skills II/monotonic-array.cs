public class Solution {
    public bool IsMonotonic(int[] nums) {
        var resultDec = true;
        var resultInc = true;
        var N = nums.Length;
        
        for (int i = 1; i < N && (resultDec || resultInc); i++) {
            if (resultInc && nums[i - 1] > nums[i]) {
                resultInc = false;
            }
            if (resultDec && nums[i - 1] < nums[i]) {
                resultDec = false;
            }
        }
        
        return resultDec || resultInc;
    }
}