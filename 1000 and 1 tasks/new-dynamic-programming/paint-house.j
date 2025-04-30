import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// TL

class Solution {

    final int RED = 1;
    final int GREEN = 2;
    final int BLUE = 3;

    private int min = Integer.MAX_VALUE;

    private int[][] costs;

    private void F(int i, int prevColor, int score) {
        if (i == this.costs.length) {
            this.min = Math.min(this.min, score);
            return;
        }

        // red
        if (prevColor != RED) {
            F(i + 1, RED, score + this.costs[i][0]);
        }
        // green
        if (prevColor != GREEN) {
            F(i + 1, GREEN, score + this.costs[i][1]);
        }
        // blue
        if (prevColor != BLUE) {
            F(i + 1, BLUE, score + this.costs[i][2]);
        }
    }

    public int minCost(int[][] costs) {
        this.costs = costs;

        F(0, 0, 0);

        return this.min;
    }
}
