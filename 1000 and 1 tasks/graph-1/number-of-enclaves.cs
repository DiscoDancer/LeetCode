public class Solution {
    private bool[][] Visited;
    private int LandSize = 0;

    private void ProcessIsland(int[][] grid, int x0, int y0) {
        var X = grid.Length;
        var Y = grid[0].Length;

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((x0,y0));
        Visited[x0][y0] = true;

        var isIslandValid = true;
        var islandLength = 0;

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();
            islandLength++;
            // не надо досрочно выходить, потому что мы еще размечает острова
            if (isIslandValid) {
                isIslandValid = x != X-1 && y != Y-1 && x != 0 && y != 0;
            }
            
            if (x > 0 && grid[x-1][y] == 1 && !Visited[x-1][y]) {
                queue.Enqueue((x-1,y));
                Visited[x-1][y] = true;
            }

            if (x < X - 1 && grid[x+1][y] == 1 && !Visited[x+1][y]) {
                queue.Enqueue((x+1,y));
                Visited[x+1][y] = true;
            }

            if (y > 0 && grid[x][y-1] == 1 && !Visited[x][y-1]) {
                queue.Enqueue((x,y-1));
                Visited[x][y-1] = true;
            }

            if (y < Y - 1 && grid[x][y+1] == 1 && !Visited[x][y+1]) {
                queue.Enqueue((x,y+1));
                Visited[x][y+1] = true;
            }
        }

        if (isIslandValid) {
            LandSize += islandLength;
        }
        
    }

    // найти остров окруженный морем, только плюсовать его длину
    public int NumEnclaves(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;

        Visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            Visited[i] = new bool[Y];
        }

        for (int x = 0; x < X; x++) {
            for (int y = 0; y < Y; y++) {
                if (grid[x][y] == 0 || Visited[x][y]) {
                    continue;
                }
                ProcessIsland(grid, x, y);
            }
        }

        return LandSize;
    }
}