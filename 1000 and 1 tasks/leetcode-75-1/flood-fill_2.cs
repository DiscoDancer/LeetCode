public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        var targetColor = image[sr][sc];

        if (color == targetColor) {
            return image;
        }

        var X = image.Length;
        var Y = image[0].Length;

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((sr, sc));

        

        while (queue.Any()) {
            var (x,y) = queue.Dequeue();
            image[x][y] = color;

            if (x > 0 && image[x-1][y] == targetColor) {
                queue.Enqueue((x-1, y));
            }
            if (y > 0 && image[x][y-1] == targetColor) {
                queue.Enqueue((x, y-1));
            }

            if (x < X - 1 && image[x+1][y] == targetColor) {
                queue.Enqueue((x+1, y));
            }
            if (y < Y - 1 && image[x][y+1] == targetColor) {
                queue.Enqueue((x, y + 1));
            }
        }

        return image;
    }
}