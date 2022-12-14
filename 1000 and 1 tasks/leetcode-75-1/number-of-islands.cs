public class Solution {
    // 

    private bool[,]  _visited;
    private int _islands = 0;

    private void ProcessIsland(char[][] grid, int _x, int _y) {
        _islands++;
        var X = grid.Length;
        var Y = grid[0].Length;

        var queue = new Queue<(int x, int y)>();
        _visited[_x,_y] = true; 
        queue.Enqueue((_x,_y));

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();

            if (x > 0 && grid[x-1][y] == '1' && !_visited[x-1, y]) {
                _visited[x-1,y] = true;
                queue.Enqueue((x-1,y));
            }
            if (x < X - 1 && grid[x+1][y] == '1' && !_visited[x+1, y]) {
                _visited[x+1,y] = true;
                queue.Enqueue((x+1,y));
            }

            if (y > 0 && grid[x][y-1] == '1' && !_visited[x, y-1]) {
                _visited[x,y-1] = true;
                queue.Enqueue((x,y-1));
            }
            if (y < Y - 1 && grid[x][y+1] == '1' && !_visited[x, y+1]) {
                _visited[x,y+1] = true;
                queue.Enqueue((x,y+1));
            }
        }
    }

    public int NumIslands(char[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;

        _visited = new bool[X,Y];

        for (int x = 0; x < X; x++) {
            for (int y = 0; y < Y; y++) {
                if (grid[x][y] == '0') {
                    continue;
                }
                if (!_visited[x,y]) {
                    ProcessIsland(grid, x, y);
                }
            }
        }

        return _islands++;
    }
}