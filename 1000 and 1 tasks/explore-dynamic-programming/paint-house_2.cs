public class Solution {
    public const int RED = 0;
    public const int BLUE = 1;
    public const int GREEN = 2;

    // passes
    public int MinCost(int[][] costs) {
        var n = costs.Length;

        var table = new int[n+1, 3];

        for (var index = n-1; index >= 0; index--) {
            for (var color = 0; color < 3; color++ ) {
                var a = int.MaxValue;
                var b = int.MaxValue;
                var c = int.MaxValue;

                if (color != RED) {
                    a = table[index+1, RED] + costs[index][RED];
                }
                if (color != BLUE) {
                    b = table[index+1, BLUE] + costs[index][BLUE];
                }
                if (color != GREEN) {
                    c = table[index+1, GREEN] + costs[index][GREEN];
                }

                table[index, color] = Math.Min(a,Math.Min(b,c));
            }
        }

        return Math.Min(table[0,RED], Math.Min(table[0, BLUE], table[0, GREEN]));
    }
}