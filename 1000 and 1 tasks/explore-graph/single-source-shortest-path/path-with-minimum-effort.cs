public class Solution {
    // heights: rows x columns
    // heights[row][col] represents the height of cell (row, col)
    // (0,0) -> (rows-1, columns-1)
    // ou can move up, down, left, or right
    public int MinimumEffortPath(int[][] heights) {
        var X = heights.Length;
        var Y = heights[0].Length;

        var table = new int[X][];
        for (int i = 0; i < X; i++) {
            table[i] = new int[Y];
            for (int j = 0; j < Y; j++) {
                table[i][j] = int.MaxValue;
            }
        }
        table[0][0] = 0;

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((0,0));

        while (queue.Any()) {
            var (x,y) = queue.Dequeue();
            if (x > 0) {
                var diff = Math.Abs(heights[x][y] - heights[x-1][y]);
                var option = x == 0 && y == 0 ? diff : Math.Max(diff, table[x][y]);
                if (table[x-1][y] > option) {
                    table[x-1][y] = option;
                    queue.Enqueue((x-1,y));
                }
            }
            if (x < X - 1) {
                var diff = Math.Abs(heights[x][y] - heights[x+1][y]);
                var option = x == 0 && y == 0 ? diff : Math.Max(diff, table[x][y]);
                if (table[x+1][y] > option) {
                    table[x+1][y] = option;
                    queue.Enqueue((x+1,y));
                }
            }
            if (y > 0) {
                var diff = Math.Abs(heights[x][y] - heights[x][y-1]);
                var option = x == 0 && y == 0 ? diff : Math.Max(diff, table[x][y]);
                if (table[x][y-1] > option) {
                    table[x][y-1] = option;
                    queue.Enqueue((x,y-1));
                }
            }
            if (y < Y - 1) {
                var diff = Math.Abs(heights[x][y] - heights[x][y+1]);
                var option = x == 0 && y == 0 ? diff : Math.Max(diff, table[x][y]);
                if (table[x][y+1] > option) {
                    table[x][y+1] = option;
                    queue.Enqueue((x,y+1));
                }
            }
        }

        return table.Last().Last();
    }
}