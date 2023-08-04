public class Solution {
    // TL
    public int MaxSubarraySumCircular(int[] nums) {
        var best = -1000001;
        var cur = best;

        // n kadane
        for (var start = 0; start < nums.Length; start++) {
            cur = -1000001;
            for (int i = 0; i < nums.Length; i++) {
                var n = nums[(i + start) % nums.Length];
                cur = Math.Max(n + cur, n);
                best = Math.Max(cur, best);
            }
        }

        return best;
    }
}