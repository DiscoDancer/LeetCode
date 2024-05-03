public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        var X = heights.Length;
        var Y = heights[0].Length;

        var mapPacific = new bool[X,Y];

        var queue = new Queue<(int x, int y)>();
        for (int i = 0; i < Y; i++) {
            queue.Enqueue((0, i));
            mapPacific[0,i] = true;
        }
        // 1 чтобы 2 раза не обработать
        for (int i = 1; i < X; i++) {
            queue.Enqueue((i, 0));
            mapPacific[i,0] = true;
        }

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();
            if (x > 0 && heights[x-1][y] >= heights[x][y] && !mapPacific[x-1,y]) {
                queue.Enqueue((x-1,y));
                mapPacific[x-1,y] = true;
            }
            if (x < X - 1 && heights[x+1][y] >= heights[x][y] && !mapPacific[x+1,y]) {
                queue.Enqueue((x+1,y));
                mapPacific[x+1,y] = true;
            }

            if (y > 0 && heights[x][y-1] >= heights[x][y] && !mapPacific[x,y-1]) {
                queue.Enqueue((x,y-1));
                mapPacific[x,y-1] = true;
            }

            if (y < Y - 1 && heights[x][y+1] >= heights[x][y] && !mapPacific[x,y+1]) {
                queue.Enqueue((x,y+1));
                mapPacific[x,y+1] = true;
            }
        }
        
        var mapAtlantic = new bool[X,Y];
        for (int i = 0; i < Y; i++) {
            queue.Enqueue((X-1, i));
            mapAtlantic[X-1,i] = true;
        }
        for (int i = 0; i < X - 1; i++) {
            queue.Enqueue((i, Y-1));
            mapAtlantic[i,Y-1] = true;
        }
        
        while (queue.Any()) {
            var (x, y) = queue.Dequeue();
            if (x > 0 && heights[x-1][y] >= heights[x][y] && !mapAtlantic[x-1,y]) {
                queue.Enqueue((x-1,y));
                mapAtlantic[x-1,y] = true;
            }
            if (x < X - 1 && heights[x+1][y] >= heights[x][y] && !mapAtlantic[x+1,y]) {
                queue.Enqueue((x+1,y));
                mapAtlantic[x+1,y] = true;
            }

            if (y > 0 && heights[x][y-1] >= heights[x][y] && !mapAtlantic[x,y-1]) {
                queue.Enqueue((x,y-1));
                mapAtlantic[x,y-1] = true;
            }

            if (y < Y - 1 && heights[x][y+1] >= heights[x][y] && !mapAtlantic[x,y+1]) {
                queue.Enqueue((x,y+1));
                mapAtlantic[x,y+1] = true;
            }
        }

        var result = new List<IList<int>>();

        for (int x = 0; x < X; x++)
        {
            for (int y = 0; y < Y; y++)
            {
                if (mapPacific[x, y] && mapAtlantic[x, y])
                {
                    result.Add([x, y]);
                }
            }
        }
        
        return result;
    }
}