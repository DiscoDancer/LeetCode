public class Solution {
    public int MinCost(int[][] costs) {
        var n = costs.Length;
        var table = new int[n+1, 3];

        for (int index = n-1; index >= 0; index--) {
            for (int color = 0; color <= 2; color++) {
                var min = int.MaxValue;
                for (int prevColor = 0; prevColor <= 2; prevColor++) {
                    if (prevColor != color) {
                        min = Math.Min(min, costs[index][color] + table[index + 1, prevColor]);
                    }
                }
                table[index, color] = min;
            }
            
        }

        return new int[] {
            table[0,0],
            table[0,1],
            table[0,2],
        }
        .Min();
    }
}