public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        // очередь
        // visited
        // process

        var X = image.Length;
        var Y = image[0].Length;

        var visited = new bool[X, Y];
        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((sr, sc));

        var targetColor = image[sr][sc];

        while (queue.Any()) {
            var (x,y) = queue.Dequeue();
            image[x][y] = color;
            visited[x, y] = true;

            if (x > 0 && image[x-1][y] == targetColor && !visited[x-1, y]) {
                queue.Enqueue((x-1, y));
            }
            if (y > 0 && image[x][y-1] == targetColor && !visited[x, y-1]) {
                queue.Enqueue((x, y-1));
            }

            if (x < X - 1 && image[x+1][y] == targetColor && !visited[x+1, y]) {
                queue.Enqueue((x+1, y));
            }
            if (y < Y - 1 && image[x][y+1] == targetColor && !visited[x, y+1]) {
                queue.Enqueue((x, y + 1));
            }
        }

        return image;
    }
}