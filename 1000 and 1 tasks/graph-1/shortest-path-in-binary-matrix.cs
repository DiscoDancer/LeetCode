public class Solution {
    // такая же спиралька
    // как только встретили последнюю - выход или если спиралька кончилась тоже выход
    public int ShortestPathBinaryMatrix(int[][] grid) {
        if (grid[0][0] == 1) {
            return -1;
        }

        var X = grid.Length;
        var Y = grid[0].Length;

        var visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            visited[i] = new bool[Y];
        }

        var queue = new Queue<(int x, int y, int level)>();
        queue.Enqueue((0,0,1));
        visited[0][0] = true;

        while (queue.Any()) {
            var (x,y, level) = queue.Dequeue();

            if (x == X-1 && y == Y - 1) {
                return level;
            }

            if (x > 0 && !visited[x-1][y] && grid[x-1][y] == 0) {
                queue.Enqueue((x-1,y, level+1));
                visited[x-1][y] = true;
            }

            if (x < X-1 && !visited[x+1][y] && grid[x+1][y] == 0) {
                queue.Enqueue((x+1,y, level+1));
                visited[x+1][y] = true;
            }

            if (y > 0 && !visited[x][y-1] && grid[x][y-1] == 0) {
                queue.Enqueue((x,y-1, level+1));
                visited[x][y-1] = true;
            }

            if (y < Y-1 && !visited[x][y+1] && grid[x][y+1] == 0) {
                queue.Enqueue((x,y+1, level+1));
                visited[x][y+1] = true;
            }

            // top right
            if (x < X-1 && y < Y-1 && !visited[x+1][y+1] && grid[x+1][y+1] == 0) {
                queue.Enqueue((x+1,y+1, level+1));
                visited[x+1][y+1] = true;
            }

            // top left
            if (x < X-1 && y > 0 && !visited[x+1][y-1] && grid[x+1][y-1] == 0) {
                queue.Enqueue((x+1,y-1, level+1));
                visited[x+1][y-1] = true;
            }

            // top right
            if (x > 0 && y < Y-1 && !visited[x-1][y+1] && grid[x-1][y+1] == 0) {
                queue.Enqueue((x-1,y+1, level+1));
                visited[x-1][y+1] = true;
            }

            // top left
            if (x > 0  && y > 0 && !visited[x-1][y-1] && grid[x-1][y-1] == 0) {
                queue.Enqueue((x-1,y-1, level+1));
                visited[x-1][y-1] = true;
            }
        }

        return -1;
    }
}