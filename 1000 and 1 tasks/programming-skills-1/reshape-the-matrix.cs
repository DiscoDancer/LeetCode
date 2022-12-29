public class Solution {
    public int[][] MatrixReshape(int[][] mat, int r, int c) {
        var X = mat.Length;
        var Y = mat[0].Length;

        if (X * Y != r * c) {
            return mat;
        }

        var newMat = new int [r][];
        for (int i = 0; i < r; i++) {
            newMat[i] = new int[c];
        }

        var count = X*Y;
        for (int i = 0; i < count; i++) {
            var cur = mat[i / Y][i % Y];
            newMat[i / c][i % c] = cur;
        }

        return newMat;
    }
}