public class Solution {
    // сразу перекрашивать и перескакивать
    public void SetZeroes(int[][] matrix) {
        var X = matrix.Length;
        var Y = matrix[0].Length;

        var cols = new bool[Y];

        for (int i = 0; i < matrix.Length; i++) {
            var zeroLine = false;
            for (int j = 0; j < matrix[0].Length; j++) {
                if (matrix[i][j] == 0) {
                    cols[j] = true;

                    if (!zeroLine) {
                        var k = j - 1;
                        while (k >= 0) {
                            matrix[i][k--] = 0;
                        }
                        zeroLine = true;
                    }
                }
                if (zeroLine) {
                    matrix[i][j] = 0;
                }
            }
        }

        for (int i = 0; i < matrix.Length; i++) {
            for (int j = 0; j < matrix[0].Length; j++) {
                if (cols[j]) {
                    matrix[i][j] = 0;
                }
            }
        }
    }
}