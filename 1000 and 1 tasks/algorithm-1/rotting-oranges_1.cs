public class Solution {
    public int OrangesRotting(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;
        var freshCount = 0;

        var queue = new Queue<(int x, int y)>();

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (grid[i][j] == 2) {
                    queue.Enqueue((i, j));
                }
                else if (grid[i][j] == 1) {
                    freshCount++;
                }
            }
        }

        if (freshCount == 0) {
            return 0;
        }

        queue.Enqueue((-1, -1));

        var minutes = -1;

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();

            if (x == -1) {
                minutes++;
                if (queue.Any()) {
                    queue.Enqueue((-1, -1));
                }
            }
            else {
                if (x < X - 1 && grid[x+1][y] == 1) {
                    grid[x+1][y] = 2;
                    freshCount--;
                    queue.Enqueue((x+1, y));
                }
                if (y < Y - 1 && grid[x][y+1] == 1) {
                    grid[x][y+1] = 2;
                    freshCount--;
                    queue.Enqueue((x, y+1));
                }

                if (x > 0 && grid[x-1][y] == 1) {
                    grid[x-1][y] = 2;
                    freshCount--;
                    queue.Enqueue((x-1, y));
                }
                if (y > 0 && grid[x][y-1] == 1) {
                    grid[x][y-1] = 2;
                    freshCount--;
                    queue.Enqueue((x, y-1));
                }
            }
        }

        return freshCount == 0 ? minutes : -1;
    }
}