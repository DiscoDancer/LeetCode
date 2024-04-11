public class Solution {
    // найти самые близкие точки, по ним будет понятен ответ
    // немного бинарного поиска, чтобы не было квадрата
    // или мб расстояние от середины

    private int[,] CreateMap(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;

        var map = new int[X,Y];

        var inslandNumber = 1;

        for (int i = 0; i < X && inslandNumber < 3; i++) {
            for (int j = 0; j < Y && inslandNumber < 3; j++) {
                if (map[i,j] == 0 && grid[i][j] == 1) {
                    var queue = new Queue<(int x, int y)>();
                    queue.Enqueue((i,j));

                    var visited = new bool[X,Y];
                    visited[i,j] = true;

                    while (queue.Any()) {
                        var (x,y) = queue.Dequeue();
                        map[x,y] = inslandNumber;

                        if (x < X - 1 && grid[x+1][y] == 1 && !visited[x+1,y]) {
                            visited[x+1,y] = true;
                            queue.Enqueue((x+1, y));
                        }
                        if (x > 0 && grid[x-1][y] == 1 && !visited[x - 1,y]) {
                            visited[x-1,y] = true;
                            queue.Enqueue((x-1, y));
                        }

                        if (y < Y - 1 && grid[x][y+1] == 1 && !visited[x,y+1]) {
                            visited[x,y+1] = true;
                            queue.Enqueue((x, y+1));
                        }
                        if (y > 0 && grid[x][y-1] == 1 && !visited[x,y-1]) {
                            visited[x,y-1] = true;
                            queue.Enqueue((x, y-1));
                        }
                    }
                    inslandNumber++;
                }
            }
        }

        return map;
    }

    // пускаем волны от угла
    public int ShortestBridge(int[][] grid) {
        // 0 water
        // 1 island 1
        // 2 island 2
        // 0 water
        // 1 island 1
        // 2 island 2
        var map = CreateMap(grid);

        var island1Points = new  List<(int x, int y)>();
        var island2Points = new  List<(int x, int y)>();

        var X = grid.Length;
        var Y = grid[0].Length;

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (map[i,j] == 1) {
                    island1Points.Add((i,j));
                }
                else if (map[i,j] == 2) {
                    island2Points.Add((i,j));
                }
            }
        }

        var min = int.MaxValue;

        foreach (var p1 in island1Points) {
            foreach (var p2 in island2Points) {
                var xDiff = Math.Abs(p1.x - p2.x);
                var yDiff = Math.Abs(p1.y - p2.y);

                var diff = xDiff - 1 + yDiff;
                min = Math.Min(min, diff);
            }
        }

        return min;
    }
}