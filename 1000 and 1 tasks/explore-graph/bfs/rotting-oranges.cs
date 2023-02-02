public class Solution {
    private const int EMPTY = 0;
    private const int FRESH = 1;
    private const int ROTTEN = 2;

    public int OrangesRotting(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;

        var queue = new Queue<(int x, int y)>();
        var rottenCount = 0;
        var freshCount = 0;

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (grid[i][j] == ROTTEN) {
                    queue.Enqueue((i,j));
                    rottenCount++;
                }
                else if (grid[i][j] == FRESH) {
                    freshCount++;
                }
            }
        }

        var expectedChildren = rottenCount;
        var level = freshCount == 0 ? 0 : 1;
        while (queue.Any()) {
            var newExpectedChildren = 0;
            for (int i = 0; i < expectedChildren; i++) {
                var (x,y) = queue.Dequeue();

                if (x > 0 && grid[x-1][y] == FRESH) {
                    grid[x-1][y] = ROTTEN;
                    queue.Enqueue((x-1, y));
                    newExpectedChildren++;
                    freshCount--;
                }
                if (x < X-1 && grid[x+1][y] == FRESH) {
                    grid[x+1][y] = ROTTEN;
                    queue.Enqueue((x+1, y));
                    newExpectedChildren++;
                    freshCount--;
                }

                if (y > 0 && grid[x][y-1] == FRESH) {
                    grid[x][y-1] = ROTTEN;
                    queue.Enqueue((x, y-1));
                    newExpectedChildren++;
                    freshCount--;
                }
                if (y < Y-1 && grid[x][y+1] == FRESH) {
                    grid[x][y+1] = ROTTEN;
                    queue.Enqueue((x, y+1));
                    newExpectedChildren++;
                    freshCount--;
                }
            }
            if (freshCount == 0) {
                return level;
            }
            expectedChildren = newExpectedChildren;
            level++;
        }

        if (freshCount != 0) {
            return -1;
        }

        return 0;
    }
}