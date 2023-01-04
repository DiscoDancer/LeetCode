public class Solution {

    private int[][] _mat;
    private int[][] _res;

    private void ZeroRefill(int x, int y, bool initial = false) {
        var X = _res.Length;
        var Y = _res[0].Length;

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (_mat[i][j] == 0) {
                    _res[i][j] = 0;
                }
                else {
                    var d = Math.Abs(x - i) + Math.Abs(y - j);
                    if (initial) {
                        _res[i][j] = d;
                    }
                    else {
                        _res[i][j] = Math.Min(_res[i][j], d);
                    }
                }
            }
        }
    }

    /*
        Roadmap:
        + refill foreach zero (n^4)
        - список нулей и не нулей, выбирать минимум
    */

    public int[][] UpdateMatrix(int[][] mat) {
        var X = mat.Length;
        var Y = mat[0].Length;

        _mat = mat;
        _res = new int[X][];
        for (int i = 0; i < X; i++) {
            _res[i] = new int[Y];
        }

        var initial = true;

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (mat[i][j] == 0) {
                    ZeroRefill(i, j, initial);
                    if (initial) {
                        initial = false;
                    }
                }
            }
        }

        return _res;
    }
}