import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;

class Solution {

    // ищем последний индекс меньгего элемента
    private int binarySearchLastLess(int[][] intervals, int target) {
        int left = 0;
        int right = intervals.length - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (intervals[mid][1] < target && (mid == intervals.length - 1 || intervals[mid + 1][1] >= target)) {
                return mid;
            }
            else if (intervals[mid][1] < target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return -1;
    }

    public int[][] insert(int[][] intervals, int[] newInterval) {
        var listBefore = new ArrayList<int[]>();
        var listIntersect = new ArrayList<int[]>();
        var listAfter = new ArrayList<int[]>();

        var lastIndexLess = binarySearchLastLess(intervals, newInterval[0]);
        if (lastIndexLess != -1) {
            for (int i = 0; i <= lastIndexLess; i++) {
                listBefore.add(intervals[i]);
            }
        }

        for (int i = lastIndexLess + 1; i < intervals.length; i++) {
            var interval = intervals[i];
            if (interval[0] > newInterval[1]) {
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