public class Solution {

    private int D((int xx, int yy) pair, int x , int y) {
        var (xx, yy) = pair;
        return Math.Abs(xx - x) + Math.Abs(yy - y);
    }

    public int[][] UpdateMatrix(int[][] mat) {
        var X = mat.Length;
        var Y = mat[0].Length;

        var zeroes = new List<(int x, int y)>();

        var res = new int[X][];
        for (int i = 0; i < X; i++) {
            res[i] = new int[Y];
        }

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (mat[i][j] == 0) {
                    zeroes.Add((i, j));
                }
            }
        }

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (mat[i][j] == 0) {
                    res[i][j] = 0;
                }
                else {
                    res[i][j] = zeroes.Select(x => D(x, i, j)).Min();
                }
            }
        }

        return res;
    }
}