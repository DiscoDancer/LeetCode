public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;

        var visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            visited[i] = new bool[Y];
        }
        visited[0][0] = true;

        var queue = new Queue<(int x, int y, int level)>();
        if (grid[0][0] == 0) {
            queue.Enqueue((0,0,0));
        }
        
        while (queue.Any()) {
            var (x,y,level) = queue.Dequeue();

            if (x == X - 1 && y == Y - 1) {
                return level + 1;
            }

            if (x > 0 && !visited[x-1][y] && grid[x-1][y] == 0) {
                visited[x-1][y] = true;
                queue.Enqueue((x-1,y,level+1));
            }
            if (x < X - 1 && !visited[x+1][y] && grid[x+1][y] == 0) {
                visited[x+1][y] = true;
                queue.Enqueue((x+1,y,level+1));
            }

            if (y > 0 && !visited[x][y-1] && grid[x][y-1] == 0) {
                visited[x][y-1] = true;
                queue.Enqueue((x,y-1,level+1));
            }
            if (y < Y - 1 && !visited[x][y+1] && grid[x][y+1] == 0) {
                visited[x][y+1] = true;
                queue.Enqueue((x,y+1,level+1));
            }

            if (y > 0 && x > 0 && !visited[x-1][y-1] && grid[x-1][y-1] == 0) {
                visited[x-1][y-1] = true;
                queue.Enqueue((x-1,y-1,level+1));
            }
            if (y > 0 && x < X-1 && !visited[x+1][y-1] && grid[x+1][y-1] == 0) {
                visited[x+1][y-1] = true;
                queue.Enqueue((x+1,y-1,level+1));
            }

            if (y < Y-1 && x > 0 && !visited[x-1][y+1] && grid[x-1][y+1] == 0) {
                visited[x-1][y+1] = true;
                queue.Enqueue((x-1,y+1,level+1));
            }
            if (y < Y-1 && x < X-1 && !visited[x+1][y+1] && grid[x+1][y+1] == 0) {
                visited[x+1][y+1] = true;
                queue.Enqueue((x+1,y+1,level+1));
            }
        }

        return -1;
    }
}