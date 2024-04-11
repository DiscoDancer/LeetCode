public class Solution {
    public int NearestExit(char[][] maze, int[] entrance) {
        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((entrance[0], entrance[1]));

        var X = maze.Length;
        var Y = maze[0].Length;

        var visited = new bool[X,Y];
        visited[entrance[0],entrance[1]] = true;

        var roundCount = 0;
        while (queue.Any()) {
            var size = queue.Count();
            for (int i = 0; i < size; i++) {
                var (x,y) = queue.Dequeue();

                if (roundCount > 0 && (x == 0 || y == 0 || x == X-1 || y == Y-1)) {
                    return roundCount;
                }

                if (x < X - 1 && maze[x+1][y] == '.' && !visited[x+1,y]) {
                    visited[x+1,y] = true;
                    queue.Enqueue((x+1, y));
                }
                if (x > 0 && maze[x-1][y] == '.' && !visited[x - 1,y]) {
                    visited[x-1,y] = true;
                    queue.Enqueue((x-1, y));
                }

                if (y < Y - 1 && maze[x][y+1] == '.' && !visited[x,y+1]) {
                    visited[x,y+1] = true;
                    queue.Enqueue((x, y+1));
                }
                if (y > 0 && maze[x][y-1] == '.' && !visited[x,y-1]) {
                    visited[x,y-1] = true;
                    queue.Enqueue((x, y-1));
                }
            }
            roundCount++;
        }

        return -1;
    }
}