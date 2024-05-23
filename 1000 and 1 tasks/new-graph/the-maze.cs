public class Solution {
    // BFS
    public bool HasPath(int[][] maze, int[] start, int[] destination) {
        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((start[0], start[1]));

        var X = maze.Length;
        var Y = maze[0].Length;

        var visited = new bool[X,Y];
        visited[start[0], start[1]] = true;

        while (queue.Any()) {
            var (x,y) = queue.Dequeue();
            if (x == destination[0] && y == destination[1]) {
                return true;
            }

            var xb = x;
            var yb = y;
            while (xb < X -1  && maze[xb + 1][yb] == 0)
            {
                xb++;
            }
            if (!visited[xb, yb])
            {
                visited[xb, yb] = true;
                queue.Enqueue((xb,yb));
            }
            
            var xt = x;
            var yt = y;
            while (xt > 0  && maze[xt - 1][yb] == 0)
            {
                xt--;
            }
            if (!visited[xt, yt])
            {
                visited[xt, yt] = true;
                queue.Enqueue((xt,yt));
            }
            
            var xr = x;
            var yr = y;
            while (yr < Y -1  && maze[xr][yr+1] == 0)
            {
                yr++;
            }
            if (!visited[xr, yr])
            {
                visited[xr, yr] = true;
                queue.Enqueue((xr,yr));
            }
            
            var xl = x;
            var yl = y;
            while (yl > 0  && maze[xl][yl-1] == 0)
            {
                yl--;
            }
            if (!visited[xl, yl])
            {
                visited[xl, yl] = true;
                queue.Enqueue((xl,yl));
            }
        }

        return false;
    }
}