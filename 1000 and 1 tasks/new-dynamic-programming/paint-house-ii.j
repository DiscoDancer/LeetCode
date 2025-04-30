import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// see prev: https://leetcode.com/problems/paint-house/description/?envType=study-plan-v2&envId=dynamic-programming


class Solution {
    public int minCostII(int[][] costs) {
        var k = costs[0].length;
        var table = new int[costs.length + 1][k + 1];

        for (var i = costs.length - 1; i >= 0; i--) {
            for (var prevColor = k; prevColor >= 0; prevColor--) {
                if (prevColor == 0 && i != 0) {
                    continue;
                }

                var min = Integer.MAX_VALUE;

                for (var curColor = k; curColor >= 1; curColor--) {
                    if (prevColor == curColor) {
                        continue;
                    }

                    var cost = costs[i][curColor - 1] + table[i + 1][curColor];
                    min = Math.min(min, cost);
                }

                table[i][prevColor] = min;
            }
        }

        return table[0][0];
    }
}
