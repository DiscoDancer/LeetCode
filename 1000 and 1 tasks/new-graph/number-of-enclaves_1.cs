public class Solution {
    private int[][] _grid;
    private int[,] _map;
    private List<int> _islandSizes = new();
    private List<bool> _isValidIsland = new();

    /*
     * Roadmap:
     * + сначала разметить
     * + потом длины островов посчитать
     * + потом вычеркнуть плохие острова
     */

    private int F(int x, int y, int islandCurrentNumber)
    {
        var grid = _grid;
        var map = _map;

        var X = grid.Length;
        var Y = grid[0].Length;

        if (x == 0 || y == 0 || x == X - 1 || y == Y - 1)
        {
            _isValidIsland[islandCurrentNumber - 1] = false;
        }

        var islandSize = 1;

        if (x < X - 1 && map[x + 1, y] == 0 && grid[x + 1][y] == 1)
        {
            map[x + 1, y] = islandCurrentNumber;
            islandSize += F(x + 1, y, islandCurrentNumber);
        }

        if (x > 0 && map[x - 1, y] == 0 && grid[x - 1][y] == 1)
        {
            map[x - 1, y] = islandCurrentNumber;
            islandSize += F(x - 1, y, islandCurrentNumber);
        }

        if (y < Y - 1 && map[x, y + 1] == 0 && grid[x][y + 1] == 1)
        {
            map[x, y + 1] = islandCurrentNumber;
            islandSize += F(x, y + 1, islandCurrentNumber);
        }

        if (y > 0 && map[x, y - 1] == 0 && grid[x][y - 1] == 1)
        {
            map[x, y - 1] = islandCurrentNumber;
            islandSize += F(x, y - 1, islandCurrentNumber);
        }

        return islandSize;
    }

    // острова без касания стенок
    public int NumEnclaves(int[][] grid)
    {
        var X = grid.Length;
        var Y = grid[0].Length;

        _map = new int[X, Y];
        _grid = grid;

        var islandCurrentNumber = 1;

        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                if (grid[i][j] == 1 && _map[i, j] == 0)
                {
                    _map[i, j] = islandCurrentNumber;
                    _isValidIsland.Add(true);
                    _islandSizes.Add(F(i, j, islandCurrentNumber));
                    islandCurrentNumber++;
                }
            }
        }

        var result = 0;
        for (var i = 0; i < _isValidIsland.Count; i++)
        {
            if (_isValidIsland[i])
            {
                result += _islandSizes[i];
            }
        }

        return result;
    }
}