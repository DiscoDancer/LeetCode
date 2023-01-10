public class Solution {
    public int MaxScoreSightseeingPair(int[] values) {
        var bestPrev = Math.Max(values[0] + 0, values[1] + 1);
        var max = values[0] + values[1] - 1;

        for (int i = 2; i < values.Length; i++) {
            max = Math.Max(max, bestPrev + values[i] - i);
            bestPrev = Math.Max(bestPrev, values[i] + i);
        }

        return max;
    }
}