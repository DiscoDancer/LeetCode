public class Solution {
    // red blue green
    private int[][] _costs;

    public const int RED = 0;
    public const int BLUE = 1;
    public const int GREEN = 2;

    private int F(int index, int prevColor) {
        if (index == _costs.Length) {
            return 0;
        }

        var a = int.MaxValue;
        var b = int.MaxValue;
        var c = int.MaxValue;

        if (prevColor != RED) {
            a = F(index+1, RED) + _costs[index][RED];
        }
        if (prevColor != BLUE) {
            b = F(index+1, BLUE) + _costs[index][BLUE];
        }
        if (prevColor != GREEN) {
            c = F(index+1, GREEN) + _costs[index][GREEN];
        }

        return Math.Min(a,Math.Min(b,c));
    }

    // still TL
    public int MinCost(int[][] costs) {
        _costs = costs;

        return F(0, -1);
    }
}