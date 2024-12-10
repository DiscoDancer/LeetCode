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

    // ищем индекс первого элемента большего
    private int binarySearchFirstBigger(int[][] intervals, int target, int leftStart) {
        int left = leftStart;
        int right = intervals.length - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (intervals[mid][0] > target && (mid == 0 || intervals[mid - 1][0] <= target)) {
                return mid;
            }
            else if (intervals[mid][0] <= target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return -1;
    }

    public int[][] insert(int[][] intervals, int[] newInterval) {
        var lastIndexLess = binarySearchLastLess(intervals, newInterval[0]);
        var firstIndexBigger = binarySearchFirstBigger(intervals, newInterval[1], lastIndexLess + 1);

        var lessCount = lastIndexLess + 1;
        var biggerCount = firstIndexBigger == -1 ? 0 : intervals.length - firstIndexBigger;
        var affectedCount = intervals.length - lessCount - biggerCount;
        var resultCount = lessCount + biggerCount + 1;


        var result = new int[resultCount][2];
        for (int i = 0; i < lessCount; i++) {
            result[i] = intervals[i];
        }
        for (int i = 0; i < biggerCount; i++) {
            result[lessCount + 1 + i] = intervals[firstIndexBigger + i];
        }
        if (affectedCount > 0) {
            newInterval[0] = Math.min(newInterval[0], intervals[lessCount][0]);
            newInterval[1] = Math.max(newInterval[1], intervals[lessCount + affectedCount - 1][1]);
            result[lessCount] = newInterval;
        }
        else {
            result[lessCount] = newInterval;
        }
        return result;
    }
}