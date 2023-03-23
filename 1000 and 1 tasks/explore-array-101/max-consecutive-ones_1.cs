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
                max = Math.Max(max, cur);
                cur = 0;
            }
            
            prev = n;
        }

        max = Math.Max(max, cur);
        return max;
    }
}