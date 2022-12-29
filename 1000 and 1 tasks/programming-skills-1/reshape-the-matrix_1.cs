public class Solution {
    public int[][] MatrixReshape(int[][] mat, int r, int c) {
        var X = mat.Length;
        var Y = mat[0].Length;
        var count = X*Y;

        if (count != r * c) {
            return mat;
        }

        var newMat = new int [r][];
        for (int i = 0; i < count; i++) {
            var cur = mat[i / Y][i % Y];
            if (i % c == 0) {
                newMat[i / c] = new int[c];
            }
            newMat[i / c][i % c] = cur;
        }

        return newMat;
    }
}