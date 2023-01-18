public class Solution {
    private bool[][] Visited;
    private int MaxIsland = 0;

    private void ProcessIsland(int[][] grid, int x0, int y0) {
        var curSize = 1;

        var X = grid.Length;
        var Y = grid[0].Length;

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((x0,y0));
        Visited[x0][y0] = true;

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();

            if (x > 0 && grid[x-1][y] == 1 && !Visited[x-1][y]) {
                queue.Enqueue((x-1,y));
                Visited[x-1][y] = true;
                curSize++;
            }

            if (x < X - 1 && grid[x+1][y] == 1 && !Visited[x+1][y]) {
                queue.Enqueue((x+1,y));
                Visited[x+1][y] = true;
                curSize++;
            }

            if (y > 0 && grid[x][y-1] == 1 && !Visited[x][y-1]) {
                queue.Enqueue((x,y-1));
                Visited[x][y-1] = true;
                curSize++;
            }

            if (y < Y - 1 && grid[x][y+1] == 1 && !Visited[x][y+1]) {
                queue.Enqueue((x,y+1));
                Visited[x][y+1] = true;
                curSize++;
            }
        }

        MaxIsland = Math.Max(MaxIsland, curSize);
    }

    public int MaxAreaOfIsland(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;

        Visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            Visited[i] = new bool[Y];
        }

        for (int x = 0; x < X; x++) {
            for (int y = 0; y < Y; y++) {
                if (grid[x][y] == 0 || Visited[x][y]) {
                    continue;
                }
                ProcessIsland(grid, x, y);
            }
        }

        return MaxIsland;
    }
}