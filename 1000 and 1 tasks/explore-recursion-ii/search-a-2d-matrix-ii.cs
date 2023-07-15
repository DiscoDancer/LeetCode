public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        foreach (var row in matrix) {
            var found = Array.BinarySearch(row, target);
            if (found >= 0) {
                return true;
            }
        }

        return false;
    }
}