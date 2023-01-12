public class Solution {
    // для каждого элемента считать min, за который можно туда придти
    // оптимизация то же с одним массивом
    public int MinFallingPathSum(int[][] matrix) {
        var prevRow = matrix[0].ToArray(); // copy
        for (var row = 1; row < matrix.Length; row++) {
            var prevOld = -1;
            for (var col = 0; col < matrix[0].Length; col++) {
                var old = prevRow[col];
                var min = prevRow[col];
                if (col > 0) {
                    min = Math.Min(min, prevOld);
                }
                if (col < matrix[0].Length - 1) {
                    min = Math.Min(min, prevRow[col+1]);
                }
                prevRow[col] = matrix[row][col] + min;
                prevOld = old;
            }
        }

        return prevRow.Min();
    }
}