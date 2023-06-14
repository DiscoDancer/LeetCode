public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        if (image[sr][sc] == color) {
            return image;
        }

        var X = image.Length;
        var Y = image[0].Length;
        var old = image[sr][sc];

        var queue = new Queue<(int x, int y)>();
        image[sr][sc] = color;
        queue.Enqueue((sr, sc));

        while (queue.Any()) {
            var (x,y) = queue.Dequeue();

            if (x < X -1 && image[x+1][y] == old) {
                image[x+1][y] = color;
                queue.Enqueue((x+1, y));
            }
            if (x > 0 && image[x-1][y] == old) {
                image[x-1][y] = color;
                queue.Enqueue((x-1, y));
            }

            if (y < Y -1 && image[x][y+1] == old) {
                image[x][y+1] = color;
                queue.Enqueue((x, y + 1));
            }
            if (y > 0 && image[x][y-1] == old) {
                image[x][y-1] = color;
                queue.Enqueue((x, y-1));
            }
        }

        return image;
    }
}