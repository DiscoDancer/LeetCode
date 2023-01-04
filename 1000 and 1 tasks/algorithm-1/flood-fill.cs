public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        var previousColor = image[sr][sc];
        var newColor = color;

        if (previousColor == newColor) {
            return image;
        }

        var X = image.Length;
        var Y = image[0].Length;

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((sr, sc));
        image[sr][sc] = newColor;

        while (queue.Any()) {
            var (x,y) = queue.Dequeue();
            
            if (x < X - 1 && image[x+1][y] == previousColor) {
                image[x+1][y] = newColor;
                queue.Enqueue((x+1, y));
            }
            if (x > 0 && image[x-1][y] == previousColor) {
                image[x-1][y] = newColor;
                queue.Enqueue((x-1, y));
            }

            if (y < Y - 1 && image[x][y + 1] == previousColor) {
                image[x][y+1] = newColor;
                queue.Enqueue((x, y + 1));
            }
            if (y > 0 && image[x][y -1] == previousColor) {
                image[x][y-1] = newColor;
                queue.Enqueue((x, y - 1));
            }
        }

        return image;
    }
}