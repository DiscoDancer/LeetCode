public class Solution {
    public bool BS(int[] arr, int target) {
        var a = 0;
        var b = arr.Length - 1;

        while (a <= b) {
            var m = (b-a)/2 + a;
            if (arr[m] == target) {
                return true;
            }
            else if (arr[m] < target) {
                a = m + 1;
            }
            else {
                b = m - 1;
            }
        }

        return false;
    }

    public bool SearchMatrix(int[][] matrix, int target) {
        foreach (var row in matrix) {
            var found = BS(row, target);
            if (found) {
                return true;
            }
        }
        return false;
    }
}