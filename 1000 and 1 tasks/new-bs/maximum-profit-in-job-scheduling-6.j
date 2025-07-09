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

    public int jobScheduling(int[] startTime, int[] endTime, int[] profit) {

        this.entries = new ArrayList<>(startTime.length);
        for (int i = 0; i < startTime.length; i++) {
            entries.add(new Entry(startTime[i], endTime[i], profit[i]));
        }
        entries.sort(Entry::compareTo);



        var table = new long[entries.size()];
        for (int i = 0; i < entries.size(); i++) {
            table[i] = entries.get(i).profit;
        }

        for (var i = entries.size() - 1; i >= 0; i--) {
            for (var j = i + 1; j < entries.size(); j++) {
                if (entries.get(i).end <= entries.get(j).start) {
                    table[i] = Math.max(table[i], entries.get(i).profit + table[j]);
                }
            }
        }

        var max = 0;
        for (int i = 0; i < entries.size(); i++) {
            max = Math.max(max, (int) table[i]);
        }

        return max;
    }
}