public class Solution {
    // optimization based on editorial
    public int MinCostII(int[][] costs) {
        var n = costs.Length;
        var k = costs[0].Length;
        var prevRow = new int[k];

        for (int index = n-1; index >= 0; index--) {
            var newRow = new int[k];

            (int v, int color) min = (int.MaxValue, -1);
            (int v, int color) min2 = (int.MaxValue, -1);

            for (int color = 0; color < prevRow.Length; color++) {
                if (prevRow[color] < min.v) {
                    min2 = min;
                    min = (prevRow[color], color);
                }
                else if (prevRow[color] < min2.v) {
                    min2 = (prevRow[color], color);
                }
            }

            for (int color = 0; color <= k-1; color++) {
                if (min.color == color) {
                    newRow[color] = min2.v + costs[index][color];
                }
                else {
                    newRow[color] = min.v + costs[index][color];
                }
            }
            prevRow = newRow;
        }

        return prevRow.Min();
    }
}