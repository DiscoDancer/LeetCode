public class Solution {
    // n*n too slow
    public int MaxScoreSightseeingPair(int[] values) {
        var best = 0;

        for (int i = 0; i < values.Length; i++) {
            for (int j = i + 1; j < values.Length; j++) {
                best = Math.Max(best, values[i] + values[j] + i - j);
            }
        }

        return best;
    }
}