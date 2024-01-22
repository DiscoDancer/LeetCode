public class Solution {
    // кодируем остров списоком относительных расстояний

    private int[][] _grid;
    private bool[,] _visited;
    private List<List<(int x, int y)>> _registry = new ();

    private void Add(List<(int x, int y)> list) {
        var canAdd = true;

        var similars = _registry.Where(x => x.Count() == list.Count()).ToArray();
        foreach (var s in similars) {
            var allEquals = true;
            for (int i = 0; i < s.Count(); i++) {
                allEquals &= list[i].x == s[i].x && list[i].y == s[i].y;
            }
            if (allEquals) {
                canAdd = false;
                break;
            }
        }

        if (canAdd) {
            _registry.Add(list);
        }
    }

    private void Traverse(int x0, int y0)
    {
        var queue = new Queue<(int x, int y)>();
        _visited[x0, y0] = true;
        queue.Enqueue((x0, y0));

        var X = _grid.Length;
        var Y = _grid[0].Length;

        var list = new List<(int x, int y)>();

        while (queue.Any())
        {
            var xy = queue.Dequeue();
            var x = xy.x;
            var y = xy.y;
            list.Add((x0 - x, y0 - y));

            if (x < X - 1 && !_visited[x + 1, y] && _grid[x + 1][y] == 1)
            {
                _visited[x + 1, y] = true;
                queue.Enqueue((x + 1, y));
            }

            if (x > 0 && !_visited[x - 1, y] && _grid[x - 1][y] == 1)
            {
                _visited[x - 1, y] = true;
                queue.Enqueue((x - 1, y));
            }

            if (y < Y - 1 && !_visited[x, y + 1] && _grid[x][y + 1] == 1)
            {
                _visited[x, y + 1] = true;
                queue.Enqueue((x, y + 1));
            }

            if (y > 0 && !_visited[x, y - 1] && _grid[x][y - 1] == 1)
            {
                _visited[x, y - 1] = true;
                queue.Enqueue((x, y - 1));
            }
        }

        Add(list);
    }

    public int NumDistinctIslands(int[][] grid) {
        _grid = grid;
        var X = grid.Length;
        var Y = grid[0].Length;

        _visited = new bool[X,Y];

        for (int x = 0; x < X; x++) {
            for (int y = 0; y < Y; y++) {
                if (grid[x][y] == 0 || _visited[x,y]) {
                    continue;
                }
                // not visited island
                Traverse(x,y);
            }
        }

        return _registry.Count();
    }
}