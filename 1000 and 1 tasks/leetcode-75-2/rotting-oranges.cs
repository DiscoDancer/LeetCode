public class Solution {
    public const int EMPTY_CELL = 0;
    public const int FRESH_ORANGE = 1;
    public const int ROTTEN_ORANGE = 2;

    // посчитать fresh, мб никогда не сгниет

    public int OrangesRotting(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;
        var queue = new Queue<(int x, int y, int generation)>();

        var freshCount = 0;
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (grid[i][j] == ROTTEN_ORANGE) {
                    queue.Enqueue((i,j,0));
                }
                else if (grid[i][j] == FRESH_ORANGE) {
                    freshCount++;
                }
            }
        }

        var maxGeneration = 0;

        while (queue.Any()) {
            var (x, y, generation) = queue.Dequeue();
            maxGeneration = Math.Max(maxGeneration, generation);

            if (x > 0 && grid[x-1][y] == FRESH_ORANGE) {
                grid[x-1][y] = ROTTEN_ORANGE;
                queue.Enqueue((x-1,y,generation+1));
                freshCount--;
            }
            if (y > 0 && grid[x][y-1] == FRESH_ORANGE) {
                grid[x][y-1] = ROTTEN_ORANGE;
                queue.Enqueue((x,y-1,generation+1));
                freshCount--;
            }
            if (x < X - 1 && grid[x+1][y] == FRESH_ORANGE) {
                grid[x+1][y] = ROTTEN_ORANGE;
                queue.Enqueue((x+1,y,generation+1));
                freshCount--;
            }
            if (y < Y - 1 && grid[x][y+1] == FRESH_ORANGE) {
                grid[x][y+1] = ROTTEN_ORANGE;
                queue.Enqueue((x,y+1,generation+1));
                freshCount--;
            }
        }

        if (freshCount > 0) {
            return -1;
        }
        return maxGeneration;
    }
}