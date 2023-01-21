public class Solution {
    // . = empty, + = wall
    // entrance(x,y)

    /*
        План решения:
        1. идем во все непосещенные строны с level+1
        2. если x == 0 или y == 0, min обновляем
    */

    public int NearestExit(char[][] maze, int[] entrance) {
        var X = maze.Length;
        var Y = maze[0].Length;

        var visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            visited[i] = new bool[Y];
        }

        var queue = new Queue<(int x, int y, int level)>();
        queue.Enqueue((entrance[0],entrance[1], 0));
        visited[entrance[0]][entrance[1]] = true;

        while (queue.Any()) {
            var (x,y, level) = queue.Dequeue();
            if (!(x == entrance[0] && y == entrance[1])) {
                if (x == 0 || x == X - 1 || y == 0 || y == Y-1) {
                    return level;
                }
            }

            if (x > 0 && !visited[x-1][y] && maze[x-1][y] == '.') {
                queue.Enqueue((x-1,y, level+1));
                visited[x-1][y] = true;
            }

            if (x < X-1 && !visited[x+1][y] && maze[x+1][y] == '.') {
                queue.Enqueue((x+1,y, level+1));
                visited[x+1][y] = true;
            }

            if (y > 0 && !visited[x][y-1] && maze[x][y-1] == '.') {
                queue.Enqueue((x,y-1, level+1));
                visited[x][y-1] = true;
            }

            if (y < Y-1 && !visited[x][y+1] && maze[x][y+1] == '.') {
                queue.Enqueue((x,y+1, level+1));
                visited[x][y+1] = true;
            }
        }

        return -1;
    }
}