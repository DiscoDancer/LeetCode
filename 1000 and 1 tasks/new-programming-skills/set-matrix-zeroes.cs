public class Solution {
    // сразу перекрашивать и перескакивать
    public void SetZeroes(int[][] matrix) {
        var X = matrix.Length;
        var Y = matrix[0].Length;

        var lines = new bool[X];
        var cols = new bool[Y];

        for (int i = 0; i < matrix.Length; i++) {
            for (int j = 0; j < matrix[0].Length; j++) {
                if (matrix[i][j] == 0) {
                    lines[i] = true;
                    cols[j] = true;
                }
            }
        }

        for (int i = 0; i < matrix.Length; i++) {
            for (int j = 0; j < matrix[0].Length; j++) {
                if (cols[j] || lines[i]) {
                    matrix[i][j] = 0;
                }
            }
        }
    }
}