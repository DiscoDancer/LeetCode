public class Solution {
    // тоже взял старое решение в основу
    private bool[][] _visited;

    private int ProcessIsland(int[][] grid, int x0, int y0) {
        var X = grid.Length;
        var Y = grid[0].Length;

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((x0,y0));
        _visited[x0][y0] = true;
        
        var area = 0;

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();
            area++;
            
            if (x > 0 && grid[x-1][y] == 1 && !_visited[x-1][y]) {
                queue.Enqueue((x-1,y));
                _visited[x-1][y] = true;
            }

            if (x < X - 1 && grid[x+1][y] == 1 && !_visited[x+1][y]) {
                queue.Enqueue((x+1,y));
                _visited[x+1][y] = true;
            }

            if (y > 0 && grid[x][y-1] == 1 && !_visited[x][y-1]) {
                queue.Enqueue((x,y-1));
                _visited[x][y-1] = true;
            }

            if (y < Y - 1 && grid[x][y+1] == 1 && !_visited[x][y+1]) {
                queue.Enqueue((x,y+1));
                _visited[x][y+1] = true;
            }
        }

        return area;
    }

    // найти остров окруженный морем, только плюсовать его длину
    public int MaxAreaOfIsland(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;

        _visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            _visited[i] = new bool[Y];
        }

        var result = 0;

        for (int x = 0; x < X; x++) {
            for (int y = 0; y < Y; y++) {
                if (grid[x][y] == 0 || _visited[x][y]) {
                    continue;
                }

                result = Math.Max(result, ProcessIsland(grid, x, y));
            }
        }

        return result;
    }
}