// скопировал идею про расширение первого острова и дальше сам
// вероятно, надо расширять самый большой остров
public class Solution {


    private int[,] CreateMap(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;

        var map = new int[X,Y];

        var inslandNumber = 1;

        for (int i = 0; i < X && inslandNumber < 3; i++) {
            for (int j = 0; j < Y && inslandNumber < 3; j++) {
                if (map[i,j] == 0 && grid[i][j] == 1) {
                    var queue = new Queue<(int x, int y)>();
                    queue.Enqueue((i,j));

                    var visited = new bool[X,Y];
                    visited[i,j] = true;

                    while (queue.Any()) {
                        var (x,y) = queue.Dequeue();
                        map[x,y] = inslandNumber;

                        if (x < X - 1 && grid[x+1][y] == 1 && !visited[x+1,y]) {
                            visited[x+1,y] = true;
                            queue.Enqueue((x+1, y));
                        }
                        if (x > 0 && grid[x-1][y] == 1 && !visited[x - 1,y]) {
                            visited[x-1,y] = true;
                            queue.Enqueue((x-1, y));
                        }

                        if (y < Y - 1 && grid[x][y+1] == 1 && !visited[x,y+1]) {
                            visited[x,y+1] = true;
                            queue.Enqueue((x, y+1));
                        }
                        if (y > 0 && grid[x][y-1] == 1 && !visited[x,y-1]) {
                            visited[x,y-1] = true;
                            queue.Enqueue((x, y-1));
                        }
                    }
                    inslandNumber++;
                }
            }
        }

        return map;
    }

    public int ShortestBridge(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;
        
        // отмечаем на карте 1 и 2 остров
        var map = CreateMap(grid);

        // собираем точке перврого острова, чтобы расширять его
        var queue = new Queue<(int x, int y)>();
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (map[i,j] == 1) {
                    queue.Enqueue((i,j));
                }
            }
        }

        var roundCount = 0;
        while (queue.Any())
        {
            var size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var (x,y) = queue.Dequeue();

                if (x < X - 1)
                {
                    switch (map[x + 1, y])
                    {
                        case 0:
                            map[x + 1, y] = 1;
                            queue.Enqueue((x+1, y));
                            break;
                        case 2:
                            return roundCount;
                    }
                }
                if (x > 0)
                {
                    switch (map[x - 1, y])
                    {
                        case 0:
                            map[x - 1, y] = 1;
                            queue.Enqueue((x-1, y));
                            break;
                        case 2:
                            return roundCount;
                    }
                }
                if (y < Y - 1)
                {
                    switch (map[x, y + 1])
                    {
                        case 0:
                            map[x, y + 1] = 1;
                            queue.Enqueue((x, y+1));
                            break;
                        case 2:
                            return roundCount;
                    }
                }
                if (y > 0)
                {
                    switch (map[x, y - 1])
                    {
                        case 0:
                            map[x, y - 1] = 1;
                            queue.Enqueue((x, y - 1));
                            break;
                        case 2:
                            return roundCount;
                    }
                }
            }

            roundCount++;
        }

        return -1;
    }
}