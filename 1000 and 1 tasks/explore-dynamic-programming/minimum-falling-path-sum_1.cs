public class Solution {
    public int MinFallingPathSum(int[][] matrix) {
        var m = matrix.Length;
        var n = matrix[0].Length;


        // первый ряд такой же
        var lastRow = matrix[0].ToArray();        
        var lastRowMin = int.MaxValue;

        if (m == 1) {
            return lastRow.Min();
        }

        for (int rowIndex = 1; rowIndex < m; rowIndex++) {
            var prevFromOldRow = -1;
            for (int columnIndex = 0; columnIndex < n; columnIndex++) {
                var tmp = lastRow[columnIndex];
                var min = lastRow[columnIndex];
                
                // если слева?
                if (columnIndex > 0) {
                    min = Math.Min(min, prevFromOldRow);
                }
                // если справа?
                if (columnIndex < n-1) {
                    min = Math.Min(min, lastRow[columnIndex+1]);
                }
                lastRow[columnIndex] = min + matrix[rowIndex][columnIndex];
                prevFromOldRow = tmp;

                if (rowIndex == m -1) {
                    lastRowMin = Math.Min(lastRowMin, lastRow[columnIndex]);
                }
            }    
        }

        return lastRowMin;
    }
}