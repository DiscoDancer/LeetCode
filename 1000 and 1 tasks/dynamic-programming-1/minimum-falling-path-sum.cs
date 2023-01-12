public class Solution {
    // для каждого элемента считать min, за который можно туда придти
    // оптимизация то же с одним массивом
    public int MinFallingPathSum(int[][] matrix) {
        var prevRow = matrix[0].ToArray(); // copy
        for (var row = 1; row < matrix.Length; row++) {
            var curRow = new int[matrix[0].Length];
            for (var col = 0; col < matrix[0].Length; col++) {
                var min = prevRow[col];
                if (col > 0) {
                    min = Math.Min(min, prevRow[col-1]);
                }
                if (col < matrix[0].Length - 1) {
                    min = Math.Min(min, prevRow[col+1]);
                }
                curRow[col] = matrix[row][col] + min;
            }
            prevRow = curRow;
        }

        return prevRow.Min();
    }
}