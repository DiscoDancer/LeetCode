public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        var result = 0;
        var curLength = 0;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == 1) {
                curLength++;
            }
            if (nums[i] == 0 || i == nums.Length - 1) {
                result = Math.Max(result, curLength);
                curLength = 0;
            }
        }

        return result;
    }
}