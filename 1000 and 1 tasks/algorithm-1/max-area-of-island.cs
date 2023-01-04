public class Solution {

    private int[][] _grid;
    private bool[][] _visited;

    private int FindIsland(int x0, int y0) {
        var X = _grid.Length;
        var Y = _grid[0].Length;


        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((x0, y0));
        _visited[x0][y0] = true;
        var l = 0;
        
        while (queue.Any()) {
            var (x, y) = queue.Dequeue();
            l++;

            if (x < X - 1 && !_visited[x+1][y] && _grid[x+1][y] == 1) {
                _visited[x+1][y] = true;
                queue.Enqueue((x+1, y));
            }

            if (x > 0 && !_visited[x-1][y] && _grid[x-1][y] == 1) {
                _visited[x-1][y] = true;
                queue.Enqueue((x-1, y));
            }

            if (y < Y - 1 && !_visited[x][y+1] && _grid[x][y+1] == 1) {
                _visited[x][y+1] = true;
                queue.Enqueue((x, y+1));
            }

            if (y > 0 && !_visited[x][y-1] && _grid[x][y-1] == 1) {
                _visited[x][y-1] = true;
                queue.Enqueue((x, y-1));
            }
        }

        return l;
    }

    // вместо visited топить острова можно
    public int MaxAreaOfIsland(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;

        _grid = grid;

        _visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            _visited[i] = new bool[Y];
        }

        var max = 0;

        for (int x = 0; x < X; x++) {
            for (int y = 0; y < Y; y++) {
                if (_visited[x][y]) {
                    continue;
                }

                if (grid[x][y] == 0) {
                    _visited[x][y] = true;
                }
                else {
                    max = Math.Max(max, FindIsland(x, y));
                }
            }
        }

        return max;
    }
}