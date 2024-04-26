public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        if (grid[0][0] == 1) {
            return -1;
        }

        var N = grid.Length;

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((0,0));

        var result = new int[N][];
        for (int i = 0; i < N; i++)  {
            result[i] = new int[N];
            Array.Fill(result[i], int.MaxValue);
        }
        result[0][0] = 1;

        while (queue.Any()) {
            var (x,y) = queue.Dequeue();

            if (x < N - 1 && result[x+1][y] > result[x][y] + 1 && grid[x+1][y] == 0) {
                result[x+1][y] = result[x][y] + 1;
                queue.Enqueue((x+1,y));
            }
            if (x > 0 && result[x-1][y] > result[x][y] + 1 && grid[x-1][y] == 0) {
                result[x-1][y] = result[x][y] + 1;
                queue.Enqueue((x-1,y));
            }

            if (y < N - 1 && result[x][y+1] > result[x][y] + 1 && grid[x][y+1] == 0) {
                result[x][y+1] = result[x][y] + 1;
                queue.Enqueue((x,y+1));
            }
            if (y > 0 && result[x][y-1] > result[x][y] + 1 && grid[x][y-1] == 0) {
                result[x][y-1] = result[x][y] + 1;
                queue.Enqueue((x,y-1));
            }

            if (x < N - 1 && y < N - 1 &&  result[x+1][y+1] > result[x][y] + 1 && grid[x+1][y+1] == 0) {
                result[x+1][y+1] = result[x][y] + 1;
                queue.Enqueue((x+1,y+1));
            }

            if (x > 0 && y > 0 &&  result[x-1][y-1] > result[x][y] + 1 && grid[x-1][y-1] == 0) {
                result[x-1][y-1] = result[x][y] + 1;
                queue.Enqueue((x-1,y-1));
            }

            if (x < N - 1 && y > 0 &&  result[x+1][y-1] > result[x][y] + 1 && grid[x+1][y-1] == 0) {
                result[x+1][y-1] = result[x][y] + 1;
                queue.Enqueue((x+1,y-1));
            }

            if (x > 0 && y < N - 1 &&  result[x-1][y+1] > result[x][y] + 1 && grid[x-1][y+1] == 0) {
                result[x-1][y+1] = result[x][y] + 1;
                queue.Enqueue((x-1,y+1));
            }
        }

        return result.Last().Last() == int.MaxValue ? -1 : result.Last().Last();
    }
}