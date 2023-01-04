// не работает на тесте каком-то!!
public class Solution {

    private int[][] _dist;
    private int[][] _grid;

    private void Update1() {
        var X = _grid.Length;
        var Y = _grid[0].Length;

        for (int x = 0; x < X; x++) {
            for (int y = 0; y < Y; y++) {
                if (_grid[x][y] != 1)
                {
                    continue;
                }
                int? a = null;
                int? b = null;
                int? c = null;
                int? d = null;

                if (x < X - 1) {
                    if (_grid[x+1][y] == 2) {
                        a = 1;
                    }
                    else if (_grid[x+1][y] == 1 && _dist[x+1][y] > 0) {
                        a = _dist[x+1][y] + 1;
                    }
                }

                if (y < Y - 1) {
                    if (_grid[x][y+1] == 2) {
                        b = 1;
                    }
                    else if (_grid[x][y+1] == 1 && _dist[x][y+1] > 0) {
                        b = _dist[x][y+1] + 1;
                    }
                }

                if (x > 0) {
                    if (_grid[x-1][y] == 2) {
                        c = 1;
                    }
                    else if (_grid[x-1][y] == 1 && _dist[x-1][y] > 0) {
                        c = _dist[x-1][y] + 1;
                    }
                }

                if (y > 0) {
                    if (_grid[x][y-1] == 2) {
                        d = 1;
                    }
                    else if (_grid[x][y-1] == 1 && _dist[x][y-1] > 0) {
                        d = _dist[x][y-1] + 1;
                    }
                }
                
                var neighbours= new int?[] {a,b,c,d}
                    .Where(z => z != null)
                    .Select(z => z.Value)
                    .Where(z => z > -1)
                    .ToArray();

                if (neighbours.Any())
                {
                    _dist[x][y] = neighbours.Min();
                }
            }
        }
    }

    private void Update2() {
        var X = _grid.Length;
        var Y = _grid[0].Length;

        for (int x = X-1; x >= 0; x--) {
            for (int y = Y-1; y >= 0; y--) {
                int? a = null;
                int? b = null;
                int? c = null;
                int? d = null;

                if (x < X - 1) {
                    if (_grid[x+1][y] == 2) {
                        a = 1;
                    }
                    else if (_grid[x+1][y] == 1 && _dist[x+1][y] > 0) {
                        a = _dist[x+1][y] + 1;
                    }
                }

                if (y < Y - 1) {
                    if (_grid[x][y+1] == 2) {
                        b = 1;
                    }
                    else if (_grid[x][y+1] == 1 && _dist[x][y+1] > 0) {
                        b = _dist[x][y+1] + 1;
                    }
                }

                if (x > 0) {
                    if (_grid[x-1][y] == 2) {
                        c = 1;
                    }
                    else if (_grid[x-1][y] == 1 && _dist[x-1][y] > 0) {
                        c = _dist[x-1][y] + 1;
                    }
                }

                if (y > 0) {
                    if (_grid[x][y-1] == 2) {
                        d = 1;
                    }
                    else if (_grid[x][y-1] == 1 && _dist[x][y-1] > 0) {
                        d = _dist[x][y-1] + 1;
                    }
                }

                var neighbours= new int?[] {a,b,c,d}
                    .Where(z => z != null)
                    .Select(z => z.Value)
                    .Where(z => z > -1)
                    .ToArray();

                if (neighbours.Any())
                {
                    _dist[x][y] = neighbours.Min();
                }
            }
        }
    }

    // делаем первый проход - ищем isolated, если есть - return -1
    public int OrangesRotting(int[][] grid) {
       var X = grid.Length;
        var Y = grid[0].Length;
        _grid = grid;

        _dist = new int[X][];
        var anyFresh = false;
        for (int i = 0; i < X; i++) {
            _dist[i] = new int[Y];
            for (int j = 0; j < Y; j++) {
                _dist[i][j] = -1;
                if (_grid[i][j] == 1 && !anyFresh)
                {
                    anyFresh = true;
                }
            }
        }

        if (!anyFresh)
        {
            return 0;
        }

        Update1();
        Update2();

        var max = -1;
        var anyBroken = false;
        for (int i = 0; i < X && !anyBroken; i++) {
            for (int j = 0; j < Y && !anyBroken; j++) {
                if (grid[i][j] == 1) {
                    max = Math.Max(_dist[i][j], max);
                    if (_dist[i][j] == -1)
                    {
                        anyBroken = true;
                    }
                }
            }
        }

        return anyBroken ? -1 : max;
    }

    
}