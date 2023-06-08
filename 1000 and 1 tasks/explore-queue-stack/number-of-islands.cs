public class Solution {
    private bool[][] _visited;
    private char[][] _grid;
    private int X;
    private int Y;
    private int _count = 0;

    private void FindIsland(int i, int j) {
        var queue = new Queue<(int x, int y)>();

        queue.Enqueue((i, j));

        while (queue.Any()) {
            var (curX, curY) = queue.Dequeue();

            if (curX > 0 && _grid[curX - 1][curY] == '1' && !_visited[curX - 1][curY])
            {
                _visited[curX - 1][curY] = true;
                queue.Enqueue((curX - 1, curY));
            }
            if (curX < X - 1 && _grid[curX + 1][curY] == '1' && !_visited[curX + 1][curY])
            {
                _visited[curX + 1][curY] = true;
                queue.Enqueue((curX + 1, curY));
            }

            if (curY > 0 && _grid[curX][curY - 1] == '1' && !_visited[curX][curY - 1])
            {
                _visited[curX][curY - 1] = true;
                queue.Enqueue((curX, curY - 1));
            }
            if (curY < Y - 1 && _grid[curX][curY + 1] == '1' && !_visited[curX][curY + 1])
            {
                _visited[curX][curY + 1] = true;
                queue.Enqueue((curX, curY + 1));
            }
        }

        _count++;
    }

    public int NumIslands(char[][] grid) {
        _grid = grid;
        X = grid.Length;
        Y = grid[0].Length;

        _visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            _visited[i] = new bool[Y];
        }

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (grid[i][j] == '1' && !_visited[i][j]) {
                    FindIsland(i,j);
                }
            }
        }

        return _count;
    }
}