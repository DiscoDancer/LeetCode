// взял идею из их решения

public class Solution {
    public const char START = '@';
    public const char PASS = '.';
    public const char WALL = '#';

    public int ShortestPathAllKeys(string[] grid)
    {
        var X = grid.Length;
        var Y = grid[0].Length;

        var allStatesTable = new Dictionary<string, bool[,]>
        {
            [""] = new bool[X, Y]
        };


        (int x, int y)? startPoint = null;
        var keysTotal = 0;

        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                if (grid[i][j] == START)
                {
                    startPoint = (i, j);
                }

                if (char.IsLower(grid[i][j]))
                {
                    keysTotal++;
                }
            }
        }

        var queue = new Queue<(int x, int y, string state)>();
        queue.Enqueue((startPoint.Value.x, startPoint.Value.y, ""));
        allStatesTable[""][startPoint.Value.x, startPoint.Value.y] = true;

        var pathLength = 0;
        while (queue.Any())
        {
            var size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var (x, y, state) = queue.Dequeue();
                Console.WriteLine($"pathLength:{pathLength} x:{x} y:{y} state:{state}");
                if (state.Length == keysTotal)
                {
                    return pathLength;
                }
                // всегда существует, по построению
                var visited = allStatesTable[state];
                
                // go down
                if (x < X - 1 && !visited[x + 1, y] && grid[x + 1][y] != WALL)
                {
                    // последнее условие то, что такой ключ уже есть
                    if (grid[x + 1][y] == PASS || grid[x + 1][y] == START || state.Contains(grid[x+1][y]))
                    {
                        visited[x + 1, y] = true;
                        queue.Enqueue((x+1, y, state));
                    }
                    // новый ключ
                    else if (char.IsLower(grid[x + 1][y]))
                    {
                        var newState = new string((state + grid[x + 1][y]).ToCharArray().OrderBy(c => c).ToArray());
                        if (!allStatesTable.ContainsKey(newState))
                        {
                            allStatesTable[newState] = new bool[X, Y];
                        }
                        var keyVisited = allStatesTable[newState];
                        keyVisited[x + 1, y] = true;
                        queue.Enqueue((x+1, y, newState));
                    }
                    // можем открыть замок
                    else if (char.IsUpper(grid[x+1][y]) && state.Contains(char.ToLower(grid[x+1][y])))
                    {
                        visited[x+1, y] = true;
                        queue.Enqueue((x+1, y, state));
                    }
                }
                // go up
                if (x > 0 && !visited[x - 1, y] && grid[x - 1][y] != WALL)
                {
                    if (grid[x - 1][y] == PASS || grid[x - 1][y] == START || state.Contains(grid[x-1][y]))
                    {
                        visited[x - 1, y] = true;
                        queue.Enqueue((x-1, y, state));
                    }
                    // новый ключ
                    else if (char.IsLower(grid[x - 1][y]))
                    {
                        var newState = new string((state + grid[x - 1][y]).ToCharArray().OrderBy(c => c).ToArray());
                        if (!allStatesTable.ContainsKey(newState))
                        {
                            allStatesTable[newState] = new bool[X, Y];
                        }
                        var keyVisited = allStatesTable[newState];
                        keyVisited[x - 1, y] = true;
                        queue.Enqueue((x-1, y, newState));
                    }
                    // можем открыть замок
                    else if (char.IsUpper(grid[x-1][y]) && state.Contains(char.ToLower(grid[x-1][y])))
                    {
                        visited[x-1, y] = true;
                        queue.Enqueue((x-1, y, state));
                    }
                }
                // go right
                if (y < Y - 1 && !visited[x, y+1] && grid[x][y+1] != WALL)
                {
                    if (grid[x][y+1] == PASS || grid[x][y+1] == START || state.Contains(grid[x][y+1]))
                    {
                        visited[x, y+1] = true;
                        queue.Enqueue((x, y+1, state));
                    }
                    // новый ключ
                    else if (char.IsLower(grid[x][y+1]))
                    {
                        var newState = new string((state + grid[x][y+1]).ToCharArray().OrderBy(c => c).ToArray());
                        if (!allStatesTable.ContainsKey(newState))
                        {
                            allStatesTable[newState] = new bool[X, Y];
                        }
                        var keyVisited = allStatesTable[newState];
                        keyVisited[x, y+1] = true;
                        queue.Enqueue((x, y+1, newState));
                    }
                    // можем открыть замок
                    else if (char.IsUpper(grid[x][y+1]) && state.Contains(char.ToLower(grid[x][y+1])))
                    {
                        visited[x, y+1] = true;
                        queue.Enqueue((x, y+1, state));
                    }
                }
                // go left
                if (y > 0 && !visited[x, y-1] && grid[x][y-1] != WALL)
                {
                    if (grid[x][y-1] == PASS || grid[x][y-1] == START || state.Contains(grid[x][y-1]))
                    {
                        visited[x, y-1] = true;
                        queue.Enqueue((x, y-1, state));
                    }
                    // новый ключ
                    else if (char.IsLower(grid[x][y-1]))
                    {
                        var newState = new string((state + grid[x][y-1]).ToCharArray().OrderBy(c => c).ToArray());
                        if (!allStatesTable.ContainsKey(newState))
                        {
                            allStatesTable[newState] = new bool[X, Y];
                        }
                        var keyVisited = allStatesTable[newState];
                        keyVisited[x, y-1] = true;
                        queue.Enqueue((x, y-1, newState));
                    }
                    // можем открыть замок
                    else if (char.IsUpper(grid[x][y-1]) && state.Contains(char.ToLower(grid[x][y-1])))
                    {
                        visited[x, y-1] = true;
                        queue.Enqueue((x, y-1, state));
                    }
                }
            }

            pathLength++;
        }
        
        return -1;
    }
}