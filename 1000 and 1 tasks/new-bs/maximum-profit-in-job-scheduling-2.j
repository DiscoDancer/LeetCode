import java.math.BigInteger;
import java.util.*;

// TL

class Solution {
    private ArrayList<Entry> entries;

    private record Entry(int start, int end, int profit) implements Comparable<Entry> {
        @Override
        public int compareTo(Entry o) {
            return Integer.compare(this.start, o.start);
        }
    }

    private int f(int i, int timeNow) {
        if (i >= entries.size()) {
            return 0;
        }

        var skip = f(i + 1, timeNow);

        var take = 0;
        if (entries.get(i).start >= timeNow) {
            take = entries.get(i).profit + f(i + 1, entries.get(i).end);
        }
        return Math.max(skip, take);
    }

    public int jobScheduling(int[] startTime, int[] endTime, int[] profit) {

        this.entries = new ArrayList<>(startTime.length);
        for (int i = 0; i < startTime.length; i++) {
            entries.add(new Entry(startTime[i], endTime[i], profit[i]));
        }
        entries.sort(Entry::compareTo);

        return f(0, 0);
    }
}