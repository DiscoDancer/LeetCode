public class Solution {
    public int[][] MatrixReshape(int[][] mat, int r, int c) {
        var X = mat.Length;
        var Y = mat[0].Length;
        
        if (r*c != X*Y) {
            return mat;
        }
        
        var res = new int[r][];
        for (int i = 0; i < r; i++) {
            res[i] = new int[c];
        }
        
        int k = 0;
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                res[k / c][k % c] = mat[i][j];
                k++;
            }
        }
        
        return res;
    }
}