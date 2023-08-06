public class Solution {
    public const int RED = 0;
    public const int BLUE = 1;
    public const int GREEN = 2;

    public int MinCost(int[][] costs) {
        var n = costs.Length;

        var oldRow = new int[3];
        for (var index = n-1; index >= 0; index--) {
            var newRow = new int[3];
            for (var color = 0; color < 3; color++ ) {
                var a = int.MaxValue;
                var b = int.MaxValue;
                var c = int.MaxValue;

                if (color != RED) {
                    a = oldRow[RED] + costs[index][RED];
                }
                if (color != BLUE) {
                    b = oldRow[BLUE] + costs[index][BLUE];
                }
                if (color != GREEN) {
                    c = oldRow[GREEN] + costs[index][GREEN];
                }

                newRow[color] = Math.Min(a,Math.Min(b,c));
            }
            oldRow = newRow;
        }

        return oldRow.Min();
    }
}