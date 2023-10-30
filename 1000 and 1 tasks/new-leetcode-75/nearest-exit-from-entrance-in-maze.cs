public class Solution {
    // идти от выходов
    // backtrack
    // надо идти по уровням, тогда все ок
    public int NearestExit(char[][] maze, int[] entrance) {
        var X = maze.Length;
        var Y = maze[0].Length;
        var visited = new bool[X,Y];

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((entrance[0], entrance[1]));
        visited[entrance[0], entrance[1]] = true;

        var level = 0;

        while (queue.Any()) {
            var size = queue.Count();
            for (int i = 0; i < size; i++) {
                var (x,y) = queue.Dequeue();
                if (level != 0 && (x == 0 || x == X-1 || y == 0 || y == Y - 1)) {
                    return level;
                }

                if (x > 0 && !visited[x-1,y] && maze[x-1][y] == '.') {
                    queue.Enqueue((x-1, y));
                    visited[x-1,y] = true;
                }
                if (x < X - 1 && !visited[x+1,y] && maze[x+1][y] == '.') {
                    queue.Enqueue((x+1, y));
                    visited[x+1,y] = true;
                }

                if (y > 0 && !visited[x,y-1] && maze[x][y-1] == '.') {
                    queue.Enqueue((x, y-1));
                    visited[x,y-1] = true;
                }
                if (y < Y - 1 && !visited[x,y+1] && maze[x][y+1] == '.') {
                    queue.Enqueue((x, y+1));
                    visited[x,y+1] = true;
                }
            }
            level++;
        }

        return -1;
    }
}