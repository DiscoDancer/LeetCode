public class Solution {
    /*
        foreach building:
            cascade update paths
        foreach empty lands:
            if reachable to all building
                update answer
        return answer or -1

    */
    public int ShortestDistance(int[][] grid) {
        var X = grid.Length;
        var Y = grid[0].Length;

        var buildings = new List<(int x, int y)>();

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (grid[i][j] == 1) {
                    buildings.Add((i,j));
                }
            }
        }

        var landSum = new int[X, Y];
        var landCount = new int[X, Y];
        var landState = new int [X,Y, buildings.Count()];
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (grid[i][j] == 0) {
                    for (int k = 0; k < buildings.Count(); k++) {
                        landState[i,j,k] = int.MaxValue;
                    }
                }
            }
        }
        
        for (int buildingIndex = 0; buildingIndex < buildings.Count(); buildingIndex++) {
            var building = buildings[buildingIndex];
            var queue = new Queue<(int x, int y, int d)>();
            queue.Enqueue((building.x, building.y, 0));

            while (queue.Any()) {
                var (x, y, d) = queue.Dequeue();
                landCount[x, y]++;
                if (x > 0 && grid[x-1][y] == 0 && landState[x-1, y, buildingIndex] > d + 1) {
                    if (landState[x - 1, y, buildingIndex] == int.MaxValue)
                    {
                        landSum[x - 1, y] += d + 1;
                    }
                    else
                    {
                        landSum[x - 1, y] -= landState[x - 1, y, buildingIndex];
                        landSum[x - 1, y] += d + 1;
                    }
                    landState[x-1, y, buildingIndex] = d + 1;
                    queue.Enqueue((x-1,y,d+1));
                }
                if (x < X - 1 && grid[x+1][y] == 0 && landState[x+1, y, buildingIndex] > d + 1) {
                    if (landState[x + 1, y, buildingIndex] == int.MaxValue)
                    {
                        landSum[x + 1, y] += d + 1;
                    }
                    else
                    {
                        landSum[x + 1, y] -= landState[x + 1, y, buildingIndex];
                        landSum[x + 1, y] += d + 1;
                    }
                    landState[x+1, y, buildingIndex] = d + 1;
                    queue.Enqueue((x+1,y,d+1));
                }

                if (y > 0 && grid[x][y-1] == 0 && landState[x, y-1, buildingIndex] > d + 1) {
                    if (landState[x, y - 1, buildingIndex] == int.MaxValue)
                    {
                        landSum[x, y - 1] += d + 1;
                    }
                    else
                    {
                        landSum[x, y - 1] -= landState[x, y - 1, buildingIndex];
                        landSum[x, y - 1] += d + 1;
                    }
                    landState[x, y-1, buildingIndex] = d + 1;
                    queue.Enqueue((x,y-1,d+1));
                }
                if (y < Y - 1 && grid[x][y+1] == 0 && landState[x, y+1, buildingIndex] > d + 1) {
                    if (landState[x, y + 1, buildingIndex] == int.MaxValue)
                    {
                        landSum[x, y + 1] += d + 1;
                    }
                    else
                    {
                        landSum[x, y + 1] -= landState[x, y + 1, buildingIndex];
                        landSum[x, y + 1] += d + 1;
                    }
                    landState[x, y+1, buildingIndex] = d + 1;
                    queue.Enqueue((x,y+1,d+1));
                }
            }
        }
        
        var result = int.MaxValue;

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (grid[i][j] == 0 && landCount[i,j] == buildings.Count) {
                    result = Math.Min(result, landSum[i,j]);
                }
            }
        }

        return result == int.MaxValue ? - 1 : result;
    }
}