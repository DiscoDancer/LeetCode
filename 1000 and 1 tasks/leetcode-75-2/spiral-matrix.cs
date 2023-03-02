public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        var list = new List<int>();
        var X = matrix.Length;
        var Y = matrix[0].Length;
        var visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            visited[i] = new bool[Y];
        }

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((0,0));

        while (queue.Any())
        {
            var (x, y) = queue.Dequeue();
            visited[x][y] = true;
            list.Add(matrix[x][y]);
            
            // идем вправо пока можем
            if (y < Y - 1  && !visited[x][y+1])
            {
                if (x > 0 && !visited[x-1][y])
                {
                    queue.Enqueue((x-1,y));
                }
                else
                {
                    queue.Enqueue((x,y+1));
                }
            }
            // идем вниз пока можем
            else if (x < X-1 && !visited[x+1][y])
            {
                queue.Enqueue((x+1,y));
            }
            // идем влево пока можем
            else if (y > 0 && !visited[x][y-1])
            {
                queue.Enqueue((x,y-1));
            }
            // идем вверх пока можем
            else if (x > 0 && !visited[x-1][y])
            {
                queue.Enqueue((x-1,y));
            }

        }

        return list;
    }
}