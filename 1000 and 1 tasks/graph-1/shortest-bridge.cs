public class Solution {
    /*
        Новый план:
        - карта островов 11 и 22
        - расширяем первый остров
    */


    private void FindIsland(int[][] grid, bool[][] visited, int x0, int y0, int[][] map, int marker) {
        var X = grid.Length;
        var Y = grid[0].Length;

        visited[x0][y0] = true;

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((x0,y0));

        while (queue.Any()) {
            var (x,y) = queue.Dequeue();
            map[x][y] = marker;

            if (x > 0 && !visited[x-1][y] && grid[x-1][y] == 1) {
                queue.Enqueue((x-1,y));
                visited[x-1][y] = true;
            }

            if (x < X-1 && !visited[x+1][y] && grid[x+1][y] == 1) {
                queue.Enqueue((x+1,y));
                visited[x+1][y] = true;
            }

            if (y > 0 && !visited[x][y-1] && grid[x][y-1] == 1) {
                queue.Enqueue((x,y-1));
                visited[x][y-1] = true;
            }

            if (y < Y-1 && !visited[x][y+1] && grid[x][y+1] == 1) {
                queue.Enqueue((x,y+1));
                visited[x][y+1] = true;
            }
        }
    }

    public int ShortestBridge(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;

        var visited = new bool[X][];
        var map = new int[X][];
        for (int i = 0; i < X; i++) {
            visited[i] = new bool[Y];
            map[i] = new int[Y];
        }

        var islands = 0;
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (!visited[i][j] && grid[i][j] == 1) {
                    if (islands == 0) {
                        FindIsland(grid, visited, i, j, map, 1);
                    }
                    else {
                        FindIsland(grid, visited, i, j, map, 2);
                    }
                    islands++;
                }
            }
        }

        // тут я уже нарисовал эти острова на карте
        var queue = new Queue<(int x, int y, int level)>();
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (map[i][j] == 1) {
                    queue.Enqueue((i,j, 0));
                    visited[i][j] = true;
                }
                else {
                    visited[i][j] = false;
                }
            }
        }

        while (queue.Any()) {
            var (x,y, level) = queue.Dequeue(); 
            if (map[x][y] == 2) {
                return level - 1;
            }

            if (x > 0 && !visited[x-1][y] && map[x-1][y] != 1) {
                queue.Enqueue((x-1,y, level+1));
                visited[x-1][y] = true;
            }

            if (x < X-1 && !visited[x+1][y] && map[x+1][y] != 1) {
                queue.Enqueue((x+1,y, level+1));
                visited[x+1][y] = true;
            }

            if (y > 0 && !visited[x][y-1] && map[x][y-1] != 1) {
                queue.Enqueue((x,y-1, level+1));
                visited[x][y-1] = true;
            }

            if (y < Y-1 && !visited[x][y+1] && map[x][y+1] != 1) {
                queue.Enqueue((x,y+1, level+1));
                visited[x][y+1] = true;
            }
        }

        return -1;
    }
}