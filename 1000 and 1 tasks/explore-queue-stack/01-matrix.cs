public class Solution {
    public int[][] UpdateMatrix(int[][] mat) {
        var queue = new Queue<(int x, int y)>();

        var X = mat.Length;
        var Y = mat[0].Length;

        var result = new int[X][];
        for (int i = 0; i < X; i++) {
            result[i] = new int[Y];
            for (int j = 0; j < Y; j++) {
                if (mat[i][j] != 0) {
                    result[i][j] = int.MaxValue;
                }
                else {
                    queue.Enqueue((i,j));
                }
            }
        }

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();
            var dist = result[x][y];
            var newDist = dist + 1;

            if (x < X - 1 && result[x+1][y] > newDist) {
                result[x+1][y] = newDist;
                queue.Enqueue((x+1, y));
            }
            if (x > 0 && result[x-1][y] > newDist) {
                result[x-1][y] = newDist;
                queue.Enqueue((x-1, y));
            }

            if (y < Y - 1 && result[x][y + 1] > newDist) {
                result[x][y + 1] = newDist;
                queue.Enqueue((x, y + 1));
            }
            if (y > 0 && result[x][y - 1] > newDist) {
                result[x][y-1] = newDist;
                queue.Enqueue((x, y - 1));
            }
        }

        return result;
    }
}