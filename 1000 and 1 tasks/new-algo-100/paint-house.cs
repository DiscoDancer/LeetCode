public class Solution {

    private int _min = int.MaxValue;
    private int[][] _costs;

    private void F(int index, int sum, int prevColor) {
        if (index == _costs.Length) {
            _min = Math.Min(sum, _min);
            return;
        }

        for (int color = 0; color <= 2; color++) {
            if (prevColor != color) {
                F(index + 1, sum + _costs[index][color], color);
            }
        }
    }

    public int MinCost(int[][] costs) {
        _costs = costs;
        F(0, 0, -1);
        return _min;
    }
}