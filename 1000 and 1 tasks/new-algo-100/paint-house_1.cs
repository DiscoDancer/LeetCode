public class Solution {
    private int[][] _costs;

    private int F(int index, int prevColor) {
        if (index == _costs.Length) {
            return 0;
        }

        var min = int.MaxValue;

        for (int color = 0; color <= 2; color++) {
            if (prevColor != color) {
                min = Math.Min(min, _costs[index][color] + F(index + 1, color));
            }
        }

        return min;
    }

    public int MinCost(int[][] costs) {
        _costs = costs;
        return F(0, -1);
    }
}