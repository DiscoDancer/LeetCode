public class Solution {
    // 1 = land, 0 = water
    // index out = water

    // в grid1 нужно пронумеровать все острова, тогда будет сразу понятно в одном острове или нет

    // todo разметка остров

    private bool[][] Visited1;
    private int[][] Map1;
    private int IslandCount1 = 0;

    private bool[][] Visited2;
    private int IslandCount2 = 0;

    private void ProcessIsland2(int[][] grid, int x0, int y0) {
        var X = grid.Length;
        var Y = grid[0].Length;

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((x0,y0));
        Visited2[x0][y0] = true;

        var islandValid = true;

        var prevIslandNum = -1;

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();

            if (islandValid) {
                // вода
                if (x >= Map1.Length || y >= Map1[0].Length || Map1[x][y] == 0) {
                    islandValid = false;
                }
                else if (prevIslandNum != -1 && prevIslandNum != Map1[x][y]) {
                    islandValid = false;
                }
            }

            if (x < Map1.Length && y < Map1[0].Length) {
                prevIslandNum = Map1[x][y];
            }
            
            if (x > 0 && grid[x-1][y] == 1 && !Visited2[x-1][y]) {
                queue.Enqueue((x-1,y));
                Visited2[x-1][y] = true;
            }

            if (x < X - 1 && grid[x+1][y] == 1 && !Visited2[x+1][y]) {
                queue.Enqueue((x+1,y));
                Visited2[x+1][y] = true;
            }

            if (y > 0 && grid[x][y-1] == 1 && !Visited2[x][y-1]) {
                queue.Enqueue((x,y-1));
                Visited2[x][y-1] = true;
            }

            if (y < Y - 1 && grid[x][y+1] == 1 && !Visited2[x][y+1]) {
                queue.Enqueue((x,y+1));
                Visited2[x][y+1] = true;
            }
        }

        if (islandValid) {
            IslandCount2++;
        }
    }

    private void ProcessIsland1(int[][] grid, int x0, int y0) {
        var X = grid.Length;
        var Y = grid[0].Length;

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((x0,y0));
        Visited1[x0][y0] = true;

        var currentMarker = IslandCount1 + 1;
        IslandCount1++;

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();
            Map1[x][y] = currentMarker;
            
            if (x > 0 && grid[x-1][y] == 1 && !Visited1[x-1][y]) {
                queue.Enqueue((x-1,y));
                Visited1[x-1][y] = true;
            }

            if (x < X - 1 && grid[x+1][y] == 1 && !Visited1[x+1][y]) {
                queue.Enqueue((x+1,y));
                Visited1[x+1][y] = true;
            }

            if (y > 0 && grid[x][y-1] == 1 && !Visited1[x][y-1]) {
                queue.Enqueue((x,y-1));
                Visited1[x][y-1] = true;
            }

            if (y < Y - 1 && grid[x][y+1] == 1 && !Visited1[x][y+1]) {
                queue.Enqueue((x,y+1));
                Visited1[x][y+1] = true;
            }
        }
    }

    public int CountSubIslands(int[][] grid1, int[][] grid2) {
        var X = grid1.Length;
        var Y = grid1[0].Length;

        Visited1 = new bool[X][];
        Map1 = new int[X][];
        for (int i = 0; i < X; i++) {
            Visited1[i] = new bool[Y];
            Map1[i] = new int[Y];
        }

        for (int x = 0; x < X; x++) {
            for (int y = 0; y < Y; y++) {
                if (grid1[x][y] == 0 || Visited1[x][y]) {
                    continue;
                }
                ProcessIsland1(grid1, x, y);
            }
        }

        // тут у нас готова карта первого острова
        X = grid2.Length;
        Y = grid2[0].Length;
        Visited2 = new bool[X][];
        for (int i = 0; i < X; i++) {
            Visited2[i] = new bool[Y];
        }

        for (int x = 0; x < X; x++) {
            for (int y = 0; y < Y; y++) {
                if (grid2[x][y] == 0 || Visited2[x][y]) {
                    continue;
                }
                ProcessIsland2(grid2, x, y);
            }
        }

        return IslandCount2;
    }
}