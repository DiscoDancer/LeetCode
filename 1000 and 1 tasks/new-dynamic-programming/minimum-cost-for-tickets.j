import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// TL


class Solution {

    private int[] days;
    private int[] costs;
    private int min = Integer.MAX_VALUE;

    private void F(int i, int payedIncluding, int sum) {
        if (i == days.length) {
            min = Math.min(min, sum);
            return;
        }

        var curDay = days[i];
        if (curDay <= payedIncluding) {
            F(i + 1, payedIncluding, sum);
            return;
        }

        F(i + 1, curDay + 1 - 1, sum + costs[0]);
        F(i + 1, curDay + 7 - 1, sum + costs[1]);
        F(i + 1, curDay + 30 - 1, sum + costs[2]);
    }

    public int mincostTickets(int[] days, int[] costs) {
        this.days = days;
        this.costs = costs;

        F(0, 0, 0);

        return this.min;
    }
}
