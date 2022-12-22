// алгоритм Кардана
public class Solution {
    public int MaxSubArray(int[] nums) {
        var max = nums[0];
        var list = new List<int>();

        var curSum = 0;
        foreach (var n in nums) {
            curSum += n;
            max = Math.Max(max, curSum);
            if (curSum < 0) {
                curSum = 0;
            }
        }

        return max;
    }
}