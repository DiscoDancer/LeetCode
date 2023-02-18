public class NumMatrix {

    private int[][] _sums;

    private void InitSums(int[][] matrix) {
        var X = matrix.Length;
        var Y = matrix[0].Length;

        _sums = new int[X][];
        for (int i = 0; i < X; i++) {
            _sums[i] = new int[Y];
        }

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                _sums[i][j] += matrix[i][j];
                if (j > 0)
                {
                    _sums[i][j] += _sums[i][j - 1];
                }
            }
        }

        for (int j = 0; j < Y; j++) {
            for (int i = 1; i < X; i++) {
                _sums[i][j] += _sums[i-1][j];
            }
        }
    }

    public NumMatrix(int[][] matrix) {
        InitSums(matrix);
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        // считаем большой
        var big = _sums[row2][col2]; // 38
        // считаем вверх
        var top = row1 > 0 ? _sums[row1 - 1][col2] : 0;
        // считаем лево
        var left = col1 > 0 ?  _sums[row2][col1 - 1] : 0;
        // считаем intersect
        var intersect = col1 > 0 && row1 > 0 ?  _sums[row1-1][col1 - 1] : 0;

        return big - top - left + intersect;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */