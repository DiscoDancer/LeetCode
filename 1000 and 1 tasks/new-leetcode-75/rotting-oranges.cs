public class Solution {

    public const int EMPTY = 0;
    public const int FRESH = 1;
    public const int ROTTEN = 2;

    public int OrangesRotting(int[][] grid) {
        var queue = new Queue<(int x, int y)>();

        var countFresh = 0;

        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                if (grid[i][j] == ROTTEN) {
                    queue.Enqueue((i,j));
                }
                else if (grid[i][j] == FRESH) {
                    countFresh++;
                }
            }
        }

        var seconds = -1;

        var X = grid.Length;
        var Y = grid[0].Length;

        while (queue.Any()) {
            var size = queue.Count();
            seconds++;

            for (int i = 0; i < size; i++) {
                var (x,y) = queue.Dequeue();

                if (x > 0 && grid[x-1][y] == FRESH) {
                    grid[x-1][y] = ROTTEN;
                    queue.Enqueue((x-1,y));
                    countFresh--;
                }
                if (x < X - 1 && grid[x+1][y] == FRESH) {
                    grid[x+1][y] = ROTTEN;
                    queue.Enqueue((x+1,y));
                    countFresh--;
                }

                if (y > 0 && grid[x][y-1] == FRESH) {
                    grid[x][y-1] = ROTTEN;
                    queue.Enqueue((x,y-1));
                    countFresh--;
                }
                if (y < Y - 1 && grid[x][y+1] == FRESH) {
                    grid[x][y+1] = ROTTEN;
                    queue.Enqueue((x,y+1));
                    countFresh--;
                }
            }
        }

        if (countFresh > 0) {
            return -1;
        }

        return Math.Max(seconds, 0);
    }
}