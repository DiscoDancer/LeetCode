import java.util.Arrays;
import java.util.Comparator;

// see find-minimum-in-rotated-sorted-array

class Solution {

    // вирутальные l и r и перевод координат
    public boolean searchMatrix(int[][] matrix, int target) {
        var X = matrix.length;
        var Y = matrix[0].length;

        var l = 0;
        var r = X * Y - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;
            var mx = m / Y;
            var my = m % Y;

            if (matrix[mx][my] == target) {
                return true;
            }
            if (matrix[mx][my] < target) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }

        return false;
    }
}
