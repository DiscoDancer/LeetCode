public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        var X = matrix.Length;
        var Y = matrix[0].Length;

        var result = new List<int>();

        var queue = new Queue<(int, int)>();
        queue.Enqueue((0,0));

        var visited = new HashSet<(int, int)>();
        visited.Add((0,0));

        // состоятия чередуются 
        // 0=право 1=вниз 2=влево 3=вправо
        var state = 0;

        while (queue.Any()) {
            var (x,y) = queue.Dequeue();
            result.Add(matrix[x][y]);

            // go right
            if (state == 0) {
                // if possible to go right, then go
                if (y < Y - 1 && !visited.Contains((x, y + 1))) {
                    queue.Enqueue((x, y + 1));
                    visited.Add((x, y+1));
                }
                else {
                    // go down
                    state = 1;
                    if (x < X - 1 && !visited.Contains((x+1, y))) {
                        queue.Enqueue((x+1, y));
                        visited.Add((x+1, y));
                    }
                }
            }
            // go down
            else if (state == 1) {
                if (x < X - 1 && !visited.Contains((x+1,y)) ) {
                    queue.Enqueue((x+1, y));
                    visited.Add((x+1, y));
                }
                // go left
                else {
                    state = 2;
                    if (y > 0 && !visited.Contains((x,y-1)) ) {
                        queue.Enqueue((x, y - 1));
                        visited.Add((x, y-1));
                    }
                }
            }
            // go left
            else if (state == 2) {
                if (y > 0 && !visited.Contains((x,y-1))) {
                    queue.Enqueue((x, y - 1));
                    visited.Add((x, y-1));
                }
                else {
                    // go up
                    state = 3;
                    if (x > 0 && !visited.Contains((x-1,y)) ) {
                        queue.Enqueue((x-1, y));
                        visited.Add((x-1, y));
                    }
                }
            }
            // go up
            else if (state == 3) {
                if (x > 0 && !visited.Contains((x-1,y))  ) {
                    queue.Enqueue((x-1, y));
                    visited.Add((x-1, y));
                }
                else {
                    state = 0;
                    // go right
                    if (y < Y - 1 && !visited.Contains((x,y+1)) ) {
                        queue.Enqueue((x, y + 1));
                        visited.Add((x, y+1));
                    }
                }
            }
        }

        return result;
    }
}