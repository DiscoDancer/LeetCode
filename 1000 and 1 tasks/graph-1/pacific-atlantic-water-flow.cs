public class Solution {
    // heigh sea level
    // можно пойти в обратном порядке: от океана к горе, только сделать 2 visited

    /*
        Алгоритм:
        1. находим океан 1
        2. находим океан 2
        3. пересечение = ответ
    */

    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        var X = heights.Length;
        var Y = heights[0].Length;

        // Atlantic
        var ocean1 = new bool[X][];
        for (int i = 0; i < X; i++) {
            ocean1[i] = new bool[Y];
        }

        var queue = new Queue<(int x, int y)>();

        for (int i = 0; i < X; i++) {
            queue.Enqueue((i, Y-1));
            ocean1[i][Y-1] = true;
        }

        for (int j = 0; j < Y; j++) {
            queue.Enqueue((X-1, j));
            ocean1[X-1][j] = true;
        }

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();

            if (x > 0 && !ocean1[x-1][y] && heights[x-1][y] >= heights[x][y]) {
                queue.Enqueue((x-1,y));
                ocean1[x-1][y] = true;
            }

            if (x < X-1 && !ocean1[x+1][y] && heights[x+1][y] >= heights[x][y]) {
                queue.Enqueue((x+1,y));
                ocean1[x+1][y] = true;
            }

            if (y > 0 && !ocean1[x][y-1] && heights[x][y-1] >= heights[x][y]) {
                queue.Enqueue((x,y-1));
                ocean1[x][y-1] = true;
            }

            if (y < Y-1 && !ocean1[x][y+1] && heights[x][y+1] >= heights[x][y]) {
                queue.Enqueue((x,y+1));
                ocean1[x][y+1] = true;
            }
        }

        // Pacific
        var ocean2 = new bool[X][];
        for (int i = 0; i < X; i++) {
            ocean2[i] = new bool[Y];
        }

        for (int i = 0; i < X; i++) {
            queue.Enqueue((i, 0));
            ocean2[i][0] = true;
        }

        for (int j = 0; j < Y; j++) {
            queue.Enqueue((0, j));
            ocean2[0][j] = true;
        }

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();

            if (x > 0 && !ocean2[x-1][y] && heights[x-1][y] >= heights[x][y]) {
                queue.Enqueue((x-1,y));
                ocean2[x-1][y] = true;
            }

            if (x < X-1 && !ocean2[x+1][y] && heights[x+1][y] >= heights[x][y]) {
                queue.Enqueue((x+1,y));
                ocean2[x+1][y] = true;
            }

            if (y > 0 && !ocean2[x][y-1] && heights[x][y-1] >= heights[x][y]) {
                queue.Enqueue((x,y-1));
                ocean2[x][y-1] = true;
            }

            if (y < Y-1 && !ocean2[x][y+1] && heights[x][y+1] >= heights[x][y]) {
                queue.Enqueue((x,y+1));
                ocean2[x][y+1] = true;
            }
        }

        var result = new List<IList<int>>();

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (ocean2[i][j] && ocean1[i][j]) {
                    result.Add(new List<int>() {i,j});
                }
            }
        }

        return result;
    }
}