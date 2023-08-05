public class Solution {
    public int MinFallingPathSum(int[][] matrix) {
        var m = matrix.Length;
        var n = matrix[0].Length;

        var table = new int[m, n];

        
        var lastRowMin = int.MaxValue;

        // первый ряд такой же
        for (int i = 0; i < n; i++) {
            table[0,i] = matrix[0][i];

            if (m == 1) {
                lastRowMin = Math.Min(lastRowMin, matrix[0][i]);
            }
        }

        for (int rowIndex = 1; rowIndex < m; rowIndex++) {
            for (int columnIndex = 0; columnIndex < n; columnIndex++) {
                var min = table[rowIndex-1, columnIndex];
                // если слева?
                if (columnIndex > 0) {
                    min = Math.Min(min, table[rowIndex-1, columnIndex-1]);
                }
                // если справа?
                if (columnIndex < n-1) {
                    min = Math.Min(min, table[rowIndex-1, columnIndex+1]);
                }
                table[rowIndex, columnIndex] = min + matrix[rowIndex][columnIndex];

                if (rowIndex == m -1) {
                    lastRowMin = Math.Min(lastRowMin, table[rowIndex, columnIndex]);
                }
            }    
        }

        return lastRowMin;
    }
}