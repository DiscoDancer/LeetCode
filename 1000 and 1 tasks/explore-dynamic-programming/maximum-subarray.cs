public class Solution {
    // kadane algorithm
    public int MaxSubArray(int[] nums) {
        var best = -1000001;
        var cur = best;

        foreach (var n in nums) {
            cur = Math.Max(n + cur, n);
            best = Math.Max(cur, best);
        }

        return best;
    }
}