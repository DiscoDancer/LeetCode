import java.util.Arrays;
import java.util.Comparator;

class Solution {

    // нудно найти такое х, что arr[i][0] >= x при этом arr[i][0] минимально
    private int search(int[][] arr, int x) {
        var l = 0;
        var r = arr.length - 1;
        while (l <= r) {
            var m = l + (r - l) / 2;
            if (arr[m][0] < x) {
                l = m + 1;
            } else if (arr[m][0] == x) {
                return arr[m][1];
            }
            else if (arr[m][0] > x) {
                if (m == 0 || arr[m - 1][0] < x) {
                    return arr[m][1];
                }
                r = m - 1;
            }
        }
        return -1;
    }

    public int[] findRightInterval(int[][] intervals) {
        var n = intervals.length;
        var result = new int[n];

        var searchArray = new int[n][2];
        for (var i = 0; i < n; i++) {
            searchArray[i][0] = intervals[i][0];
            searchArray[i][1] = i;
        }

        // Sorting the array by the 0th element
        Arrays.sort(searchArray, Comparator.comparingInt(a -> a[0]));

        for (var i = 0; i < n; i++) {
            result[i] = search(searchArray, intervals[i][1]);
        }

        return result;
    }
}
