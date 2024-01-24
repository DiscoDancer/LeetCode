public class Solution {
    private Dictionary<(int x, int y), List<(int x, int y, int d)>> BuildGraph(int[][] maze, int[] start)
    { 
        var X = maze.Length;
        var Y = maze[0].Length;

        var graph = new Dictionary<(int x, int y), List<(int x, int y, int d)>>();
        var visited = new bool[X, Y];
        
        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((start[0], start[1]));
        visited[start[0], start[1]] = true;

        while (queue.Any())
        {
            var (x0, y0) = queue.Dequeue();
            if (!graph.ContainsKey((x0, y0)))
            {
                graph[(x0, y0)] = new();
            }
            
            // can go down?
            if (x0 < X-1 && maze[x0+1][y0] == 0) {
                // катимся вниз насколько это возможно
                var maxDown = x0+1;
                while (maxDown + 1  < X && maze[maxDown + 1][y0] == 0) {
                    maxDown++;
                }
                if (!visited[maxDown, y0])
                {
                    var d = Math.Abs(x0 - maxDown);
                    if (!graph.ContainsKey((maxDown, y0)))
                    {
                        graph[(maxDown, y0)] = new();
                    }
                    graph[(x0, y0)].Add((maxDown, y0, d));
                    graph[(maxDown, y0)].Add((x0, y0, d));
                    visited[maxDown, y0] = true;
                    queue.Enqueue((maxDown, y0));
                }
            }
            // can go up?
            if (x0 > 0 && maze[x0-1][y0] == 0) {
                // катимся вниз насколько это возможно
                var maxUp = x0 - 1;
                while (maxUp - 1  >= 0 && maze[maxUp - 1][y0] == 0) {
                    maxUp--;
                }
                if (!visited[maxUp, y0])
                {
                    var d = Math.Abs(x0 - maxUp);
                    if (!graph.ContainsKey((maxUp, y0)))
                    {
                        graph[(maxUp, y0)] = new();
                    }
                    graph[(x0, y0)].Add((maxUp, y0, d));
                    graph[(maxUp, y0)].Add((x0, y0, d));
                    visited[maxUp, y0] = true;
                    queue.Enqueue((maxUp, y0));
                }
            }
            // can go left
            if (y0 > 0 && maze[x0][y0-1] == 0) {
                // катимся вниз насколько это возможно
                var maxLeft = y0 - 1;
                while (maxLeft - 1 >= 0 && maze[x0][maxLeft - 1] == 0) {
                    maxLeft--;
                }
                if (!visited[x0, maxLeft]) {
                    var d = Math.Abs(y0 - maxLeft);
                    if (!graph.ContainsKey((x0, maxLeft)))
                    {
                        graph[(x0, maxLeft)] = new();
                    }
                    graph[(x0, y0)].Add((x0, maxLeft, d));
                    graph[(x0, maxLeft)].Add((x0, y0, d));
                    visited[x0, maxLeft] = true;
                    queue.Enqueue((x0, maxLeft));
                }
            }
            // can go right
            if (y0 < Y - 1 && maze[x0][y0+1] == 0) {
                // катимся вниз насколько это возможно
                var maxRight = y0 + 1;
                while (maxRight + 1 < Y && maze[x0][maxRight + 1] == 0) {
                    maxRight++;
                }
                if (!visited[x0, maxRight]) {
                    var d = Math.Abs(y0 - maxRight);
                    if (!graph.ContainsKey((x0, maxRight)))
                    {
                        graph[(x0, maxRight)] = new();
                    }
                    graph[(x0, y0)].Add((x0, maxRight, d));
                    graph[(x0, maxRight)].Add((x0, y0, d));
                    visited[x0, maxRight] = true;
                    queue.Enqueue((x0, maxRight));
                }
            }
        }
        
        return graph;
    }
    
    // Deiksra + graph, but wrong answer
    public int ShortestDistance(int[][] maze, int[] start, int[] destination)
    {
        var graph = BuildGraph(maze, start);

        if (!graph.ContainsKey((destination[0], destination[1])))
        {
            return -1;
        }

        var V = graph.Keys.ToArray();
        var d = new Dictionary<(int x, int y), int>();
        var used = new Dictionary<(int x, int y), bool>();

        foreach (var v in V)
        {
            d[v] = int.MaxValue;
            used[v] = false;
        }

        var s = (start[0], start[1]);
        d[s] = 0;

        foreach (var i in V)
        {
            (int x, int y)? v = null;
            foreach (var j in V)
            {
                if (!used[j] && (v == null || d[j] < d[v.Value]))
                {
                    v = j;
                }
            }

            if (d[v.Value] == int.MaxValue)
            {
                break;
            }

            used[v.Value] = true;
            foreach (var e in graph[v.Value])
            {
                var to = (e.x, e.y);

                if (d[v.Value] + e.d < d[to])
                {
                    d[to] = d[v.Value] + e.d;
                }
            }
        }

        return d[(destination[0], destination[1])];
    }
}