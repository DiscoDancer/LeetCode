public class Solution {
    public int MaxSubArray(int[] nums) {
        var bestSum = 0;
        var curSum = 0;
        var hadAnyPositive = false;
        foreach (var n in nums) {
            curSum = Math.Max(0, curSum + n);
            bestSum = Math.Max(curSum, bestSum);
            if (!hadAnyPositive && n >= 0) {
                hadAnyPositive = true;
            }
        }

        return hadAnyPositive ? bestSum : nums.Max();
    }
}