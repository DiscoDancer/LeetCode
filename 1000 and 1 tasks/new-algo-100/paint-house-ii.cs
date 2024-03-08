public class Solution {
    // адаптация задачи I
    public int MinCostII(int[][] costs) {
        var n = costs.Length;
        var k = costs[0].Length;
        var prevRow = new int[k];

        for (int index = n-1; index >= 0; index--) {
            var newRow = new int[k];
            for (int color = 0; color <= k-1; color++) {
                var min = int.MaxValue;
                for (int prevColor = 0; prevColor <= k-1; prevColor++) {
                    if (prevColor != color) {
                        min = Math.Min(min, costs[index][color] + prevRow[prevColor]);
                    }
                }
                newRow[color] = min;
            }
            prevRow = newRow;
        }

        return prevRow.Min();
    }
}