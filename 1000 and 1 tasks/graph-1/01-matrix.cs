public class Solution {
    // самый худших вариант: n^4 - для каждого нуля обновлять расстояния
    // мой BFS снова сработает
    public int[][] UpdateMatrix(int[][] mat) {
        var X = mat.Length;
        var Y = mat[0].Length;

        var visited = new bool[X][];
        var result = new int[X][];
        for (int i = 0; i < X; i++) {
            visited[i] = new bool[Y];
            result[i] = new int[Y];
        }

        var queue = new Queue<(int x, int y, int level)>();

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (mat[i][j] == 0) {
                    queue.Enqueue((i,j,0));
                    visited[i][j] = true;
                }
            }
        }

        while (queue.Any()) {
            var (x,y, level) = queue.Dequeue();
            result[x][y] = level;

            if (x > 0 && !visited[x-1][y] && mat[x-1][y] == 1) {
                queue.Enqueue((x-1,y, level+1));
                visited[x-1][y] = true;
            }

            if (x < X-1 && !visited[x+1][y] && mat[x+1][y] == 1) {
                queue.Enqueue((x+1,y, level+1));
                visited[x+1][y] = true;
            }

            if (y > 0 && !visited[x][y-1] && mat[x][y-1] == 1) {
                queue.Enqueue((x,y-1, level+1));
                visited[x][y-1] = true;
            }

            if (y < Y-1 && !visited[x][y+1] && mat[x][y+1] == 1) {
                queue.Enqueue((x,y+1, level+1));
                visited[x][y+1] = true;
            }
        }

        return result;
    }
}