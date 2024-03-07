public class Solution {
    public int MinCost(int[][] costs) {
        var n = costs.Length;
        var prevRow = new int[3];

        for (int index = n-1; index >= 0; index--) {
            var newRow = new int[3];
            for (int color = 0; color <= 2; color++) {
                var min = int.MaxValue;
                for (int prevColor = 0; prevColor <= 2; prevColor++) {
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