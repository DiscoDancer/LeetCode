import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;

class Solution {
    public int[][] insert(int[][] intervals, int[] newInterval) {
        var listBefore = new ArrayList<int[]>();
        var listIntersect = new ArrayList<int[]>();
        var listAfter = new ArrayList<int[]>();

        for (int i = 0; i < intervals.length; i++) {
            var interval = intervals[i];
            if (interval[1] < newInterval[0]) {
                listBefore.add(interval);
            } else if (interval[0] > newInterval[1]) {
                listAfter.add(interval);
            } else {
                listIntersect.add(interval);
            }
        }

        if (listIntersect.isEmpty()) {
            listIntersect.add(newInterval);
        }
        var min = Math.min(newInterval[0], listIntersect.get(0)[0]);
        var max = Math.max(newInterval[1], listIntersect.get(listIntersect.size() - 1)[1]);
        var merged = new int[]{min, max};
        var result = new int[listBefore.size() + listAfter.size() + 1][];
        for (int i = 0; i < listBefore.size(); i++) {
            result[i] = listBefore.get(i);
        }
        result[listBefore.size()] = merged;
        for (int i = 0; i < listAfter.size(); i++) {
            result[listBefore.size() + 1 + i] = listAfter.get(i);
        }
        return result;
    }
}