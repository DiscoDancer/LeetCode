public class Solution {

    // TL

    private bool IsUnderAttack(int x, int y, List<(int x, int y)> queens) {
        foreach (var (x0, y0) in queens) {
            if (x0 == x || y0 == y || Math.Abs(x-x0) == Math.Abs(y-y0)) {
                return true;
            }
            // todo проверить диагональ
        }

        return false;
    }

    public IList<IList<string>> SolveNQueens(int n) {
        // generate options
        var queens = new List<List<(int x, int y)>>();

        for (int i = 0; i < n*n; i++) {
            queens.Add(new List<(int x, int y)>() {});
        }

        for (int size = 1; size <= n; size++) {
            var newQueens = new List<List<(int x, int y)>>();
            foreach (var queenList in queens) {
                for (int i = 0; i < n; i++) {
                    for (int j = 0; j < n; j++) {
                        if (queenList.Contains((i,j))) {
                            continue;
                        }

                        if (!IsUnderAttack(i,j, queenList)) {
                            var copy = queenList.ToList();
                            copy.Add((i,j));
                            newQueens.Add(copy);
                        }
                    }
                }
            }
            queens = newQueens;
        }

        var result = new List<IList<string>>();
        var hs = new HashSet<string>();
        foreach (var q in queens) {
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

            var sb = new StringBuilder();
            foreach (var s in strs) {
                sb.Append(s);
            }

            var key = sb.ToString();

            if (hs.Add(key)) {
                result.Add(strs);
            }
        }

        return result;
    }
}