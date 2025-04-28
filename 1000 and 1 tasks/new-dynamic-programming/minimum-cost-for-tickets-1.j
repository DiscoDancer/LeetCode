import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {

    private int[] days;
    private int[] costs;

    private int F(int i, int payedIncluding) {
        if (i == days.length) {
            return 0;
        }

        var localMin = Integer.MAX_VALUE;

        var curDay = days[i];
        if (curDay <= payedIncluding) {
            localMin = F(i + 1, payedIncluding);
        }

        localMin = Math.min(localMin,  costs[0] + F(i + 1, curDay + 1 - 1));
        localMin = Math.min(localMin,  costs[1] + F(i + 1, curDay + 7 - 1));
        localMin = Math.min(localMin,  costs[2] + F(i + 1, curDay + 30 - 1));

        return localMin;
    }

    public int mincostTickets(int[] days, int[] costs) {
        this.days = days;
        this.costs = costs;

        return F(0, 0);
    }
}
