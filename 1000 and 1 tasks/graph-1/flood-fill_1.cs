public class Solution {
    // visited можно убрать
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        if (image[sr][sc] == color) {
            return image;
        }

        var X = image.Length;
        var Y = image[0].Length;
        var prevColor = image[sr][sc];
        var newColor = color;

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((sr,sc));
        image[sr][sc] = newColor;

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();

            if (x > 0 && image[x-1][y] == prevColor) {
                image[x-1][y] = newColor;
                queue.Enqueue((x-1,y));
            }

            if (x < X - 1 && image[x+1][y] == prevColor) {
                image[x+1][y] = newColor;
                queue.Enqueue((x+1,y));
            }

            if (y > 0 && image[x][y-1] == prevColor) {
                image[x][y-1] = newColor;
                queue.Enqueue((x,y-1));
            }

            if (y < Y - 1 && image[x][y+1] == prevColor) {
                image[x][y+1] = newColor;
                queue.Enqueue((x,y+1));
            }
        }

        return image;
    }
}