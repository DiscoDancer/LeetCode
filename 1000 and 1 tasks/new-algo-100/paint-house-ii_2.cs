public class Solution {
    // maximum possible optimization based on previous solution
    public int MinCostII(int[][] costs) {
        var n = costs.Length;
        var k = costs[0].Length;

        (int v, int color) min = (0, 0);
        (int v, int color) min2 = (0, 1);

        for (int index = n-1; index >= 0; index--) {
            (int v, int color) new_min = (int.MaxValue, -1);
            (int v, int color) new_min2 = (int.MaxValue, -1);

            for (int color = 0; color <= k-1; color++) {
                var value = costs[index][color] + (min.color == color ? min2.v : min.v);

                if (value < new_min.v) {
                    new_min2 = new_min;
                    new_min = (value, color);
                }
                else if (value < new_min2.v) {
                    new_min2 = (value, color);
                }
            }

            min = new_min;
            min2 = new_min2;
        }

        return Math.Min(min.v, min2.v);
    }
}