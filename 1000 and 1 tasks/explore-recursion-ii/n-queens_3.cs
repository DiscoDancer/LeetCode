public class Solution {

    private bool IsUnderAttack(int x, int y, List<(int x, int y)> queens) {
        foreach (var (x0, y0) in queens) {
            if (x0 == x || y0 == y || Math.Abs(x-x0) == Math.Abs(y-y0)) {
                return true;
            }
        }

        return false;
    }

    private List<List<(int, int)>> _result = new List<List<(int, int)>>();
    private int _n;

    private void F(int row, List<(int, int)> queens) {
        for (int col = 0; col < _n; col++) {
            if (IsUnderAttack(row, col, queens)) {
                continue;
            }

            if (row == _n - 1) {
                var copy = queens.ToList();
                copy.Add((row, col));
                _result.Add(copy);
            }
            else {
                queens.Add((row, col));
                F(row+1, queens);
                queens.Remove((row, col));
            }
        }
    }

    public IList<IList<string>> SolveNQueens(int n) {
        _n = n;
        F(0, new List<(int, int)> () {});

        var result = new List<IList<string>>();
        foreach (var q in _result) {
            var table = new StringBuilder[n];

            for (int i = 0; i < n; i++) {
                table[i] = new StringBuilder();
                for (int j = 0; j < n; j++) {
                    table[i].Append('.');
                }
            }

            foreach (var (x,y) in q) {
                table[x][y] = 'Q';
            }

            var strs = table.Select(x => x.ToString()).ToList();
            result.Add(strs);
        }

        return result;
    }
}