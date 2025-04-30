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

    private int F(int i, int prevColor) {
        if (i == this.costs.length) {
            return 0;
        }

        var min = Integer.MAX_VALUE;
        
        if (prevColor != RED) {
            min = Math.min(min, this.costs[i][0] + F(i + 1, RED));
        }
        if (prevColor != GREEN) {
            min = Math.min(min, this.costs[i][1] + F(i + 1, GREEN));
        }
        if (prevColor != BLUE) {
            min = Math.min(min, this.costs[i][2] + F(i + 1, BLUE));
        }

        return min;
    }

    public int minCost(int[][] costs) {
        this.costs = costs;

        return F(0, 0);
    }
}
