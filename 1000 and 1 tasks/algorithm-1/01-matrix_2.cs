public class Solution {

    private int[][] _mat;
    private int[][] _res;

    private void UpdateDinamic() {
        var X = _res.Length;
        var Y = _res[0].Length;

        for (int x = 0; x < X; x++) {
            for (int y = 0; y < Y; y++) {
                if (_mat[x][y] == 0) {
                    continue;
                }

                int? a = x < X - 1 ?  _res[x+1][y] + 1 : null;
                int? b = y < Y - 1 ?  _res[x][y+1] + 1 : null;
                int? c = x > 0 ?  _res[x-1][y] + 1 : null;
                int? d = y > 0 ?  _res[x][y-1] + 1 : null;

                _res[x][y] = new int?[] {a,b,c,d, _res[x][y]}
                    .Where(z => z != null)
                    .Select(z => z.Value)
                    .Min();
            }
        }
    }

    private void UpdateDinamic2() {
        var X = _res.Length;
        var Y = _res[0].Length;

        for (int x = X - 1; x >= 0; x--) {
            for (int y = Y - 1; y >= 0; y--) {
                if (_mat[x][y] == 0) {
                    continue;
                }

                int? a = x < X - 1 ?  _res[x+1][y] + 1 : null;
                int? b = y < Y - 1 ?  _res[x][y+1] + 1 : null;
                int? c = x > 0 ?  _res[x-1][y] + 1 : null;
                int? d = y > 0 ?  _res[x][y-1] + 1 : null;

                _res[x][y] = new int?[] {a,b,c,d, _res[x][y]}
                    .Where(z => z != null)
                    .Select(z => z.Value)
                    .Min();
            }
        }
    }

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

        for (int i = 0; i < X && initial; i++) {
            for (int j = 0; j < Y && initial; j++) {
                if (mat[i][j] == 0) {
                    if (initial) {
                        ZeroRefill(i, j, initial);
                        initial = false;
                    }
                }
            }
        }

        UpdateDinamic();
        UpdateDinamic2();

        return _res;
    }
}