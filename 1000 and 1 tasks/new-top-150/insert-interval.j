import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;

class Solution {
    public int[][] merge(int[][] intervals) {
        int[][] intervalsCopy = Arrays.copyOf(intervals, intervals.length);
        Arrays.sort(intervalsCopy, Comparator.comparingInt(a -> a[0]));

        var list = new ArrayList<int[]>();

        for (var interval : intervalsCopy) {
            if (list.isEmpty()) {
                list.add(interval);
            }
            else {
                var prev = list.get(list.size() - 1);
                if (interval[0] <= prev[1]) {
                    prev[1] = Math.max(prev[1], interval[1]);
                }
                else {
                    list.add(interval);
                }
            }
        }

        return list.toArray(new int[list.size()][]);
    }

    public int[][] insert(int[][] intervals, int[] newInterval) {
        int[][] intervalsCopy = Arrays.copyOf(intervals, intervals.length + 1);
        intervalsCopy[intervals.length] = newInterval;
        return merge(intervalsCopy);
    }
}