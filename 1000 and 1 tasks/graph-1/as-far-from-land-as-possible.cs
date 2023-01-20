public class Solution {
    // 0 water
    // 1 land

    // наивное решение за n^4
    // граф по поколениям
    // помнится они там клали какой-то разделитель уровня, но пока не понятно зачем он мне
    public int MaxDistance(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;

        var visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            visited[i] = new bool[Y];
        }

        var queue = new Queue<(int x, int y, int level)>();

        var noLand = true;
        var noWater = true;
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (grid[i][j] == 1) {
                    queue.Enqueue((i,j, 0));
                    visited[i][j] = true;
                    if (noLand) {
                        noLand = false; 
                    }
                }
                else if (noWater) {
                    noWater = false;
                }
            }
        }

        if (noWater || noLand) {
            return -1;
        }

        var maxLevel = 0;
        while (queue.Any()) {
            var (x,y, level) = queue.Dequeue();
            maxLevel = Math.Max(maxLevel, level);

            if (x > 0 && !visited[x-1][y] && grid[x-1][y] == 0) {
                queue.Enqueue((x-1,y, level+1));
                visited[x-1][y] = true;
            }

            if (x < X-1 && !visited[x+1][y] && grid[x+1][y] == 0) {
                queue.Enqueue((x+1,y, level+1));
                visited[x+1][y] = true;
            }

            if (y > 0 && !visited[x][y-1] && grid[x][y-1] == 0) {
                queue.Enqueue((x,y-1, level+1));
                visited[x][y-1] = true;
            }

            if (y < Y-1 && !visited[x][y+1] && grid[x][y+1] == 0) {
                queue.Enqueue((x,y+1, level+1));
                visited[x][y+1] = true;
            }
        }

        return maxLevel;
    }
}