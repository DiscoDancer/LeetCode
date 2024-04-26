public class Solution {
    // propagate update
    // dp?
    // graph
    // start from 0 or 1
    public int[][] UpdateMatrix(int[][] mat) {
        // propagate updates from zeroes (graph)

        var X = mat.Length;
        var Y = mat[0].Length;

        var queue = new Queue<(int x, int y)>();

        var result = new int[X][];
        for (int i = 0; i < X; i++) {
            result[i] = new int[Y];
            for (int j = 0; j < Y; j++) {
                if (mat[i][j] == 0) {
                    result[i][j] = 0;
                    queue.Enqueue((i,j));
                }
                else {
                    result[i][j] = int.MaxValue;
                }
            }
        }

        while (queue.Any()) {
            var (x,y) = queue.Dequeue();

            if (x < X - 1 && result[x+1][y] > result[x][y] + 1) {
                result[x+1][y] = result[x][y] + 1;
                queue.Enqueue((x+1,y));
            }
            if (x > 0 && result[x-1][y] > result[x][y] + 1) {
                result[x-1][y] = result[x][y] + 1;
                queue.Enqueue((x-1,y));
            }

            if (y < Y - 1 && result[x][y+1] > result[x][y] + 1) {
                result[x][y+1] = result[x][y] + 1;
                queue.Enqueue((x,y+1));
            }
            if (y > 0 && result[x][y-1] > result[x][y] + 1) {
                result[x][y-1] = result[x][y] + 1;
                queue.Enqueue((x,y-1));
            }
        }

        return result;
    }
}