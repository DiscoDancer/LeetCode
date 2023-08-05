public class Solution {
    // нужно пускать волну обновлений? нет. Я так подумал потому что данные вверху не обноляются, но и пофигу
    // пробуем без нее
    public int MinPathSum(int[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;

        var table = new int[m, n];

        for (var x = 0; x < m; x++) {
            for (var y = 0; y < n; y++) {
                if (x == 0 && y == 0) {
                    table[x,y] = 0;
                }
                else if (x == 0) {
                    table[x,y] = table[x,y-1]; 
                }
                else if (y == 0) {
                    table[x,y] = table[x-1, y];
                }
                else {
                    table[x,y] = Math.Min(table[x,y-1],table[x-1, y]);
                }

                table[x,y] += grid[x][y];
            }
        }

        return table[m-1,n-1];
    }
}