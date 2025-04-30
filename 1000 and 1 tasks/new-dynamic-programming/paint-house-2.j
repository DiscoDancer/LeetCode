import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {

    final int RED = 1;
    final int GREEN = 2;
    final int BLUE = 3;

    private int[][] costs;

    public int minCost(int[][] costs) {
        this.costs = costs;

        var table = new int[costs.length + 1][4];

        for (var i = costs.length - 1; i >= 0; i--) {
            for (var prevColor = 3; prevColor >= 0; prevColor--) {
                if (prevColor == 0 && i != 0) {
                    continue;
                }

                var min = Integer.MAX_VALUE;

                if (prevColor != RED) {
                    min = Math.min(min, this.costs[i][0] + table[i + 1][ RED]);
                }
                if (prevColor != GREEN) {
                    min = Math.min(min, this.costs[i][1] + table[i + 1][ GREEN]);
                }
                if (prevColor != BLUE) {
                    min = Math.min(min, this.costs[i][2] + table[i + 1][ BLUE]);
                }

                table[i][prevColor] = min;
            }
        }

        return table[0][0];
    }
}
