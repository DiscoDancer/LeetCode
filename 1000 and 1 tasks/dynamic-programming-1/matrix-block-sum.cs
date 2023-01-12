public class Solution {
    // те же размерности матрицы
    public int[][] MatrixBlockSum(int[][] mat, int k) {
        var Rows = mat.Length;
        var Cols = mat[0].Length;

        int[][] res = new int[Rows][];

        for (int i = 0; i < Rows; i++) {
            res[i] = new int[Cols];
            for (int j = 0; j < Cols; j++) {
                
                for (var a = Math.Max(0, i-k); a <= Math.Min(Rows - 1, i + k); a++) {
                    for (var b = Math.Max(0, j-k); b <= Math.Min(Cols - 1, j + k); b++) {
                        res[i][j] += mat[a][b];
                    }
                }
            }
        }

        return res;
    }
}