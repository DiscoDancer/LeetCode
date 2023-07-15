public class Solution {
    // editorial
    public bool SearchMatrix(int[][] matrix, int target) {
        var col = 0;
        var row = matrix.Length - 1;

        while (col < matrix[0].Length && row >= 0) {
            if (matrix[row][col] == target) {
                return true;
            }

            if (matrix[row][col] < target) {
                col++;
            }
            else {
                row--;
            }
        }

        return false;
    }
}