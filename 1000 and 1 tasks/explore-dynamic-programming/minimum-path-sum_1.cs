public class Solution {
    // нужно пускать волну обновлений? нет. Я так подумал потому что данные вверху не обноляются, но и пофигу
    // пробуем без нее
    public int MinPathSum(int[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;

        var table = new int[m, n];


        var lastRow = new int[n];
        lastRow[0] = grid[0][0];
        for (int i = 1; i < n; i++) {
            lastRow[i] = lastRow[i-1] + grid[0][i];
        }

        for (var x = 1; x < m; x++) {
            for (var y = 0; y < n; y++) {
                if (y == 0) {
                    lastRow[y] = lastRow[y];
                }
                else {
                    lastRow[y] = Math.Min(lastRow[y], lastRow[y-1]);
                }

                lastRow[y] += grid[x][y];
            }
        }

        return lastRow.Last();
    }
}