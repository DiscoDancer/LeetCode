// https://leetcode.com/explore/learn/card/graph/621/algorithms-to-construct-minimum-spanning-tree/3861/
public class Solution {
    public class Point {
        public int x;
        public int y;

        public Point(int[] xy) {
            x = xy[0];
            y = xy[1];
        }

        public static int D(Point a, Point b) {
            return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
        }
    }

    public int MinCostConnectPoints(int[][] points) {
        var n = points.Length;
        var arr = points.Select(x => new Point(x)).ToArray();

        var queue = new PriorityQueue<(int indexA, int indexB), int>();
        var visited = new bool[n];
        var notVisitedCount = n;

        // начинаем с 0
        visited[0] = true;
        for (int i = 1; i < n; i++) {
            var d = Point.D(arr[0], arr[i]);
            queue.Enqueue((0, i), d);
        }
        notVisitedCount--;

        var result = 0;
        while (queue.TryDequeue(out var indexAindexB, out var d) && notVisitedCount > 0) {
            var (indexA, indexB) = indexAindexB;
            if (!visited[indexB]) {
                visited[indexB] = true;
                notVisitedCount--;

                for (int i = 0; i < n; i++) {
                    if (!visited[i]) {
                        queue.Enqueue((indexB, i), Point.D(arr[indexB], arr[i]));
                    }
                }
                result += d;
            }
        }

        return result;
    }
}