public class Solution {
    // DFS or BFS | Union Find
    private bool[][] _visited;
    private char[][] _grid;
    private int X;
    private int Y;
    private int _inslandCount = 0;

    private void FindIsland(int x, int y) {
        if (x < X - 1 && _grid[x+1][y] == '1' && !_visited[x+1][y]) {
            _visited[x + 1][y] = true;
            FindIsland(x+1, y);
        }
        if (x > 0 && _grid[x-1][y] == '1' && !_visited[x-1][y]) {
            _visited[x - 1][y] = true;
            FindIsland(x - 1, y);
        }

        if (y < Y - 1 && _grid[x][y+1] == '1' && !_visited[x][y+1]) {
            _visited[x][y + 1] = true;
            FindIsland(x, y + 1);
        }
        if (y > 0 && _grid[x][y-1] == '1' && !_visited[x][y-1]) {
            _visited[x][y - 1] = true;
            FindIsland(x, y - 1);
        }
    }

    public int NumIslands(char[][] grid) {
        X = grid.Length;
        Y = grid[0].Length;
        _visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            _visited[i] = new bool[Y];
        }
        _grid = grid;

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (grid[i][j] == '1' && !_visited[i][j]) {
                    _inslandCount++;
                    _visited[i][j] = true;
                    FindIsland(i, j);
                }
            }
        }

        return _inslandCount;
    }
}