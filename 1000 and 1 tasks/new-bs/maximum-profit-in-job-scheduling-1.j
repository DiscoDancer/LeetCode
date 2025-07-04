import java.math.BigInteger;
import java.util.*;

// TL
// DP square

class Solution {

    private int maxProfit = 0;

    private int[] startTime;
    private int[] endTime;
    private int[] profit;
    private ArrayList<Entry> entries;

    private record Entry(int start, int end, int profit) implements Comparable<Entry> {
        @Override
        public int compareTo(Entry o) {
            return Integer.compare(this.start, o.start);
        }
    }

    private void f(int i, int sum, int timeNow) {
        if (i >= startTime.length) {
            this.maxProfit = Math.max(this.maxProfit, sum);
            return;
        }

        // skip
        f(i + 1, sum, timeNow);

        // take
        var start = entries.get(i).start;
        var end = entries.get(i).end;
        var profit = entries.get(i).profit;
        if (start >= timeNow) {
            f (i + 1, sum + profit, end);
        }
    }

    public int jobScheduling(int[] startTime, int[] endTime, int[] profit) {
        this.startTime = startTime;
        this.endTime = endTime;
        this.profit = profit;

        this.entries = new ArrayList<Entry>(startTime.length);
        for (int i = 0; i < startTime.length; i++) {
            entries.add(new Entry(startTime[i], endTime[i], profit[i]));
        }
        entries.sort(Entry::compareTo);

        f(0, 0, 0);

        return this.maxProfit;
    }
}