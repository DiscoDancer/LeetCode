public class Solution {
    // red blue green
    private int[][] _costs;
    private int _min = int.MaxValue;

    public const int RED = 0;
    public const int BLUE = 1;
    public const int GREEN = 2;

    private void F(int index, int prevColor, int sum) {
        if (index == _costs.Length) {
            _min = Math.Min(_min, sum);
            return;
        }

        if (prevColor != RED) {
            F(index+1, RED, sum + _costs[index][RED]);
        }
        if (prevColor != BLUE) {
            F(index+1, BLUE, sum + _costs[index][BLUE]);
        }
        if (prevColor != GREEN) {
            F(index+1, GREEN, sum + _costs[index][GREEN]);
        }
    }

    // TL
    public int MinCost(int[][] costs) {
        _costs = costs;

        F(0, -1, 0);

        return _min;
    }
}