public class Solution {

    private int GetNth(int[][] mat, int k) {
        var X = mat.Length; // кол-во строки
        var Y = mat[0].Length; // кол-во столбы

        return mat[k / Y][k % Y];
    }

    public int[][] MatrixReshape(int[][] mat, int r, int c) {
        if (r*c != mat.Length * mat[0].Length) {
            return mat;
        }

        var res = new int[r][];

        int k = 0;
        for (int i = 0; i < r; i++) {
            res[i] = new int[c];
            for (int j = 0; j < c; j++) {
                res[i][j] = GetNth(mat, k);
                k++;
            }
        }

        return res;
    }
}