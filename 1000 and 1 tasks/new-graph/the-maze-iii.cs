// мой обычный propogate updates; но добавляем строки еще. До этого решил другие mazes

public class Solution {
    // лексикографический Дейкстра?
    public string FindShortestWay(int[][] maze, int[] ball, int[] hole) {
        var X = maze.Length;
        var Y = maze[0].Length;

        var distances = new (int d, string s)[X,Y];
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                distances[i,j] = (int.MaxValue, "z");
            }
        }
        distances[ball[0], ball[1]] = (0, "");

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((ball[0], ball[1]));

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();

            var xb = x;
            var yb = y;
            // надо останавливаться в яме
            while (xb < X -1 && !(xb == hole[0] && yb == hole[1]) && ( maze[xb + 1][yb] == 0 ||  xb+1 == hole[0] && yb == hole[1]))
            {
                xb++;
            }
            if (
                distances[xb, yb].d > distances[x, y].d + Math.Abs(xb - x) 
                || distances[xb, yb].d == distances[x, y].d + Math.Abs(xb - x) && String.CompareOrdinal(distances[xb, yb].s, distances[x,y].s + "d") > 0)
            {
                distances[xb, yb] = (distances[x, y].d + Math.Abs(xb - x), distances[x, y].s + "d");
                if (!(xb == hole[0] && yb == hole[1]))
                {
                    queue.Enqueue((xb,yb));
                }
            }
            
            var xt = x;
            var yt = y;
            // надо останавливаться в яме
            while (xt > 0 && (!(xt == hole[0] && yt == hole[1])) && ( maze[xt - 1][yt] == 0 ||  xt+1 == hole[0] && yt == hole[1]))
            {
                xt--;
            }
            if (
                distances[xt, yt].d > distances[x, y].d + Math.Abs(xt - x) 
                || distances[xt, yt].d == distances[x, y].d + Math.Abs(xt - x) && String.CompareOrdinal(distances[xt, yt].s, distances[x,y].s + "u") > 0)
            {
                distances[xt, yt] = (distances[x, y].d + Math.Abs(xt - x), distances[x, y].s + "u");
                if (!(xt == hole[0] && yt == hole[1]))
                {
                    queue.Enqueue((xt,yt));
                }
            }

            var xr = x;
            var yr = y;
            // надо останавливаться в яме
            while (yr < Y - 1 && (!(xr == hole[0] && yr == hole[1])) && ( maze[xr][yr + 1] == 0 ||  xr == hole[0] && yr+1 == hole[1]))
            {
                yr++;
            }
            if (
                distances[xr, yr].d > distances[x, y].d + Math.Abs(yr - y) 
                || distances[xr, yr].d == distances[x, y].d + Math.Abs(yr - y) && String.CompareOrdinal(distances[xr, yr].s, distances[x,y].s + "r") > 0)
            {
                distances[xr, yr] = (distances[x, y].d + Math.Abs(yr - y), distances[x, y].s + "r");
                if (!(xr == hole[0] && yr == hole[1]))
                {
                    queue.Enqueue((xr,yr));
                }
            }

            var xl = x;
            var yl = y;
            // надо останавливаться в яме
            while (yl > 0 && (!(xl == hole[0] && yl == hole[1])) && ( maze[xl][yl-1] == 0 ||  xl == hole[0] && yl-1 == hole[1]))
            {
                yl--;
            }
            if (
                distances[xl, yl].d > distances[x, y].d + Math.Abs(yl - y) 
                || distances[xl, yl].d == distances[x, y].d + Math.Abs(yl - y) && String.CompareOrdinal(distances[xl, yl].s, distances[x,y].s + "l") > 0)
            {
                distances[xl, yl] = (distances[x, y].d + Math.Abs(yl - y), distances[x, y].s + "l");
                if (!(xl == hole[0] && yl == hole[1]))
                {
                    queue.Enqueue((xl,yl));
                }
            }
        }

        return distances[hole[0], hole[1]].d == int.MaxValue ? "impossible" : distances[hole[0], hole[1]].s;
    }
}