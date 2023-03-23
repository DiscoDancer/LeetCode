public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        var max = 0;

        var prev = -1;
        var cur = 0;
        foreach (var n in nums) {
            if (n == 1) {
                cur++;
            }
            else {
                cur = 0;
            }
            max = Math.Max(max, cur);
            prev = n;
        }

        return max;
    }
}