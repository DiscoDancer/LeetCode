public class Solution {
    // visited можно убрать
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        if (image[sr][sc] == color) {
            return image;
        }

        var X = image.Length;
        var Y = image[0].Length;
        var visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            visited[i] = new bool[Y];
        }

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((sr,sc));
        visited[sr][sc] = true;
        var prevColor = image[sr][sc];
        var newColor = color;
        image[sr][sc] = newColor;

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();

            if (x > 0 && image[x-1][y] == prevColor && !visited[x-1][y]) {
                image[x-1][y] = newColor;
                queue.Enqueue((x-1,y));
                visited[x-1][y] = true;
            }

            if (x < X - 1 && image[x+1][y] == prevColor && !visited[x+1][y]) {
                image[x+1][y] = newColor;
                queue.Enqueue((x+1,y));
                visited[x+1][y] = true;
            }

            if (y > 0 && image[x][y-1] == prevColor && !visited[x][y-1]) {
                image[x][y-1] = newColor;
                queue.Enqueue((x,y-1));
                visited[x][y-1] = true;
            }

            if (y < Y - 1 && image[x][y+1] == prevColor && !visited[x][y+1]) {
                image[x][y+1] = newColor;
                queue.Enqueue((x,y+1));
                visited[x][y+1] = true;
            }
        }

        return image;
    }
}