public class Solution {
    // visited, not visited
    // max far away
    public int MinKnightMoves(int x, int y) {
        var visited = new HashSet<(int x, int y)>();
        visited.Add((0, 0));

        var initialDist = Math.Sqrt(x * x + y * y);
        const int threshold = 100;

        var queue = new Queue<(int x, int y, int d)>();
        queue.Enqueue((0, 0, 0));

        while (queue.Any()) {
            var (x0, y0, d) = queue.Dequeue();
            if (x0 == x && y0 == y) {
                return d;
            }

            var dist = Math.Sqrt((x0 - x) * (x0 - x) + (y0 - y) * (y0 - y));
            if (dist > initialDist + threshold)
            {
                continue;
            }

            
            if (visited.Add((x0 + 1, y0 + 2))) {
                queue.Enqueue((x0 + 1, y0 + 2, d + 1));
            }
            if (visited.Add((x0 + 1, y0 - 2))) {
                queue.Enqueue((x0 + 1, y0 - 2, d + 1));
            }
            if (visited.Add((x0 + 2, y0 + 1))) {
                queue.Enqueue((x0 + 2, y0 + 1, d + 1));
            }
            if (visited.Add((x0 + 2, y0 - 1))) {
                queue.Enqueue((x0 + 2, y0 - 1, d + 1));
            }

            if (visited.Add((x0 - 2, y0 + 1))) {
                queue.Enqueue((x0 - 2, y0 + 1, d + 1));
            }
            if (visited.Add((x0 - 2, y0 - 1))) {
                queue.Enqueue((x0 - 2, y0 - 1, d + 1));
            }
            if (visited.Add((x0 - 1, y0 + 2))) {
                queue.Enqueue((x0 - 1, y0 + 2, d + 1));
            }
            if (visited.Add((x0 - 1, y0 - 2))) {
                queue.Enqueue((x0 - 1, y0 - 2, d + 1));
            }
        }

        return -1;
    }
}