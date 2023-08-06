public class Solution {
    public int MinCostII(int[][] costs) {
        var n = costs.Length;
        var k = costs[0].Length;

        var oldRow = new int[k];
        for (var index = n-1; index >= 0; index--) {
            var newRow = new int[k];
            for (var color = 0; color < k; color++ ) {
                var min = int.MaxValue;
                for (var otherColor = 0; otherColor < k; otherColor++) {
                    if (otherColor != color) {
                        min = Math.Min(min, oldRow[otherColor] + costs[index][otherColor]);
                    }
                }
                
                newRow[color] = min;
            }
            oldRow = newRow;
        }

        return oldRow.Min();
    }
}