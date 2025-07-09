import java.math.BigInteger;
import java.util.*;

// memory limit


class Solution {
    private ArrayList<Entry> entries;

    private record Entry(int start, int end, int profit) implements Comparable<Entry> {
        @Override
        public int compareTo(Entry o) {
            return Integer.compare(this.start, o.start);
        }
    }

    public int jobScheduling(int[] startTime, int[] endTime, int[] profit) {

        this.entries = new ArrayList<>(startTime.length);
        // to not use -1 for prevI, we add fake 0 (sentinel)
        entries.add(new Entry(-1, -1, 0));
        for (int i = 0; i < startTime.length; i++) {
            entries.add(new Entry(startTime[i], endTime[i], profit[i]));
        }
        entries.sort(Entry::compareTo);

        var table = new int[entries.size()+1][entries.size()+1];

        for (var i = entries.size() - 1; i >= 0; i--) {
            for (var prevI = i - 1; prevI >= 0; prevI--) {
                var skip = table[i + 1][prevI];
                var take = 0;
                if (entries.get(i).start >= entries.get(prevI).end) {
                    take = entries.get(i).profit + table[i + 1][i];
                }
                table[i][prevI] = Math.max(skip, take);
            }
        }

        return table[1][0];
    }
}