public class Solution {
    // найти все Pacific
    // найти все Atlantic
    // вернуть пересечение

    private bool[][] GetVisitedPacific(int[][] heights) {
        var X = heights.Length;
        var Y = heights[0].Length;
        var queue = new Queue<(int x, int y)>();

        var visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            visited[i] = new bool[Y];
        }

        for (int i = 0; i < Y; i++) {
            visited[0][i] = true;
            queue.Enqueue((0, i));
        }

        // 1 чтобы не повторяться (0;0)
        for (int i = 1; i < X; i++) {
            visited[i][0] = true;
            queue.Enqueue((i, 0));
        }

        while (queue.Any()) {
            var (x,y) = queue.Dequeue();

            if (x < X - 1 && heights[x+1][y] >= heights[x][y] && !visited[x+1][y]) {
                visited[x+1][y] = true;
                queue.Enqueue((x+1, y));
            }
            if (x > 0 && heights[x-1][y] >= heights[x][y] && !visited[x-1][y]) {
                visited[x-1][y] = true;
                queue.Enqueue((x-1, y));
            }

            if (y < Y - 1 && heights[x][y+1] >= heights[x][y] && !visited[x][y+1]) {
                visited[x][y+1] = true;
                queue.Enqueue((x, y+1));
            }
            if (y > 0 && heights[x][y-1] >= heights[x][y] && !visited[x][y - 1]) {
                visited[x][y-1] = true;
                queue.Enqueue((x, y - 1));
            }
        }

        return visited;
    }

    private bool[][] GetVisitedAtlantic(int[][] heights) {
        var X = heights.Length;
        var Y = heights[0].Length;
        var queue = new Queue<(int x, int y)>();

        var visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            visited[i] = new bool[Y];
        }

        for (int i = 0; i < Y; i++) {
            visited[X-1][i] = true;
            queue.Enqueue((X-1, i));
        }

        // 1 чтобы не повторяться (0;0)
        for (int i = 0; i < X-1; i++) {
            visited[i][Y-1] = true;
            queue.Enqueue((i, Y-1));
        }

        while (queue.Any()) {
            var (x,y) = queue.Dequeue();

            if (x < X - 1 && heights[x+1][y] >= heights[x][y] && !visited[x+1][y]) {
                visited[x+1][y] = true;
                queue.Enqueue((x+1, y));
            }
            if (x > 0 && heights[x-1][y] >= heights[x][y] && !visited[x-1][y]) {
                visited[x-1][y] = true;
                queue.Enqueue((x-1, y));
            }

            if (y < Y - 1 && heights[x][y+1] >= heights[x][y] && !visited[x][y+1]) {
                visited[x][y+1] = true;
                queue.Enqueue((x, y+1));
            }
            if (y > 0 && heights[x][y-1] >= heights[x][y] && !visited[x][y - 1]) {
                visited[x][y-1] = true;
                queue.Enqueue((x, y - 1));
            }
        }

        return visited;
    }

    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        var X = heights.Length;
        var Y = heights[0].Length;

        var visitedP = GetVisitedPacific(heights);
        var visitedA = GetVisitedAtlantic(heights);

        var result = new List<IList<int>>();

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (visitedP[i][j] && visitedA[i][j]) {
                    result.Add(new List<int>() {i, j});
                }
            }
        }

        return result;
    }
}