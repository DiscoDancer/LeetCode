public class Solution {
    // кажется дейстра правда проще
    // по сути копипаста от the-maze-i
    public int ShortestDistance(int[][] maze, int[] start, int[] destination) {
        var X = maze.Length;
        var Y = maze[0].Length;

        var distances = new int[X,Y];
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                distances[i,j] = int.MaxValue;
            }
        }
        distances[start[0], start[1]] = 0;

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((start[0], start[1]));

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();

            var xb = x;
            var yb = y;
            while (xb < X -1  && maze[xb + 1][yb] == 0)
            {
                xb++;
            }
            if (distances[xb, yb] > distances[x,y] + Math.Abs(xb-x)) {
                distances[xb, yb] = distances[x,y] + Math.Abs(xb-x);
                queue.Enqueue((xb,yb));
            }

            var xt = x;
            var yt = y;
            while (xt > 0  && maze[xt - 1][yt] == 0)
            {
                xt--;
            }
            if (distances[xt, yt] > distances[x,y] + Math.Abs(xt-x)) {
                distances[xt, yt] = distances[x,y] + Math.Abs(xt-x);
                queue.Enqueue((xt,yt));
            }

            var xr = x;
            var yr = y;
            while (yr < Y -1  && maze[xr][yr+1] == 0)
            {
                yr++;
            }
            if (distances[xr, yr] > distances[x,y] + Math.Abs(yr-y)) {
                distances[xr, yr] = distances[x,y] + Math.Abs(yr-y);
                queue.Enqueue((xr,yr));
            }

            var xl = x;
            var yl = y;
            while (yl > 0  && maze[xl][yl-1] == 0)
            {
                yl--;
            }
            if (distances[xl, yl] > distances[x,y] + Math.Abs(yl-y)) {
                distances[xl, yl] = distances[x,y] + Math.Abs(yl-y);
                queue.Enqueue((xl,yl));
            }
        }

        if (distances[destination[0], destination[1]] == int.MaxValue) {
            return -1;
        }


        return distances[destination[0], destination[1]];
    }
}