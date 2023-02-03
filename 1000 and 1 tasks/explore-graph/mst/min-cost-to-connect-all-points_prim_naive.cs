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

        var table = new int[n][];
        for (int i = 0; i < n; i++) {
            table[i] = new int[n];
        }

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                var d = Point.D(arr[i], arr[j]);
                table[i][j] = d;
                table[j][i] = d;
            }
        }

        var visited = new List<int>();
        var notVisited = new List<int>();

        for (int i = 1; i < n; i++) {
            notVisited.Add(i);
        }
        visited.Add(0);

        var result = 0;
        var count = notVisited.Count();

        while (count > 0) {
            int minU = -1;
            var minD = int.MaxValue;
            foreach (var v in visited) {
                foreach (var u in notVisited) {
                    var d = table[v][u];
                    if (d < minD) {
                        minD = d;
                        minU = u;
                    }
                }
            }

            result += minD;
            visited.Add(minU);
            notVisited.Remove(minU);

            count = notVisited.Count();
        }

        return result;
    }
}