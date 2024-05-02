public class Solution {
    private char[][] _grid;
    private bool[,] _visited;

    private void F(int x, int y)
    {
        var grid = _grid;
        var visited = _visited;

        var X = grid.Length;
        var Y = grid[0].Length;

        if (x < X - 1 && !visited[x + 1, y] && grid[x + 1][y] == '1')
        {
            visited[x + 1, y] = true;
            F(x + 1, y);
        }

        if (x > 0 && !visited[x - 1, y] && grid[x - 1][y] == '1')
        {
            visited[x - 1, y] = true;
            F(x - 1, y);
        }

        if (y < Y - 1 && !visited[x, y + 1] && grid[x][y + 1] == '1')
        {
            visited[x, y + 1] = true;
            F(x, y + 1);
        }
        if (y > 0 && !visited[x, y-1] && grid[x][y-1] == '1')
        {
            visited[x, y-1] = true;
            F(x, y-1);
        }
    }

    // 1 land 0 water
    public int NumIslands(char[][] grid)
    {
        var X = grid.Length;
        var Y = grid[0].Length;

        _visited = new bool[X, Y];
        _grid = grid;

        var result = 0;

        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                if (grid[i][j] == '1' && !_visited[i, j])
                {
                    _visited[i, j] = true;
                    F(i, j);
                    result++;
                }
            }
        }

        return result;
    }
}