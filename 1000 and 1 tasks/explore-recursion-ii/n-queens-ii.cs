public class Solution {

    private bool IsUnderAttack(int x, int y, List<(int x, int y)> queens) {
        foreach (var (x0, y0) in queens) {
            if (x0 == x || y0 == y || Math.Abs(x-x0) == Math.Abs(y-y0)) {
                return true;
            }
        }

        return false;
    }

    private int _n;
    private int _result = 0;

    private void F(int row, List<(int, int)> queens) {
        for (int col = 0; col < _n; col++) {
            if (IsUnderAttack(row, col, queens)) {
                continue;
            }

            if (row == _n - 1) {
                _result++;
            }
            else {
                queens.Add((row, col));
                F(row+1, queens);
                queens.Remove((row, col));
            }
        }
    }

    public int TotalNQueens(int n) {
        _n = n;
        F(0, new List<(int, int)> () {});

        return _result;
    }
}