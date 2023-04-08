public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        var result = 0;
        var curLength = 0;
        var prevLength = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == 1) {
                curLength++;
            }
            if (nums[i] == 0 || i == nums.Length - 1) {
                result = Math.Max(result, curLength);
                if (prevLength != 0 && curLength != 0) {
                    result = Math.Max(result, curLength + prevLength);
                }
                prevLength = curLength;
                curLength = 0;
            }
        }

        var any0 = nums.Length != result;

        if (any0) {
            return result + 1;
        }
        return result;
    }
}