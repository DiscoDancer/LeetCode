public class Solution {
    // приоритеты right, down, left, top
    public IList<int> SpiralOrder(int[][] matrix) {
        var X = matrix.Length;
        var Y = matrix[0].Length;

        var visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            visited[i] = new bool[Y];
        }

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((0,0));
        var result = new List<int>();

        while (queue.Any()) {
            var (x, y) = queue.Dequeue();
            visited[x][y] = true;
            result.Add(matrix[x][y]);

            if (y < Y - 1 && !visited[x][y+1]) { // right
                // хоть и можем пойти направо, но сначала надо дойти до верха пример 4х4
                if (x > 0 && !visited[x-1][y]) { 
                    queue.Enqueue((x - 1, y));
                } else {
                    queue.Enqueue((x, y + 1));
                }       
            } else if (x < X - 1 && !visited[x+1][y]) { // down
                queue.Enqueue((x + 1, y));
            }
            else if (y > 0 && !visited[x][y-1]) { // left
                queue.Enqueue((x, y - 1));
            }
            else if (x > 0 && !visited[x-1][y]) { // top
                queue.Enqueue((x - 1, y));
            }
        }

        return result;
    }
}