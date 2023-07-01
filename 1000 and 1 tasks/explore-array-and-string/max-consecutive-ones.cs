public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        var result = 0;

        var curLength = 0;
        foreach (var n in nums) {
            if (n == 1) {
                curLength++;
                result = Math.Max(curLength, result);
            }
            else {
                curLength = 0;
            }
        }

        result = Math.Max(curLength, result);

        return result;
    }
}