public class Solution {

    public class Point {
        public int x;
        public int y;

        public Point(int[] xy) {
            x = xy[0];
            y = xy[1];
        }
    }

    public static int D(Point a, Point b) {
        return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
    }

    public class UnionFind {
        private Dictionary<Point, Point> _root = new ();
        private Dictionary<Point, int> _rank = new ();
        private PriorityQueue<(Point a, Point b), int> _edgesQueue = new();

        public int Calc()
        {
            var res = 0;
            while (_edgesQueue.TryDequeue(out var edge, out var d))
            {
                var (p1, p2) = edge;
                if (Union(p1, p2))
                {
                    res += d;
                }
            }

            return res;
        }

        public UnionFind(int[][] points)
        {
            var n = points.Length;
            for (var i = 0; i < n; i++)
            {
                var point = new Point(points[i]);
                _root[point] = point;
                _rank[point] = 1;
            }

            var arr = _root.Keys.ToArray();
            
            for (int i = 0; i < n; i++) {
                for (int j = i + 1; j < n; j++) {
                    var a = arr[i];
                    var b = arr[j];
                    var d = D(a, b);

                    _edgesQueue.Enqueue((a,b), d);
                }
            }
        }

        public Point Find(Point x) {
            if (x == _root[x]) {
                return x;
            }
            _root[x] = Find(_root[x]);
            return _root[x];
        }

        public bool Union(Point x, Point y)
        {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX == rootY)
            {
                return false;
            }

            if (_rank[rootX] > _rank[rootY])
            {
                _root[rootY] = rootX;
            }
            else if (_rank[rootX] < _rank[rootY])
            {
                _root[rootX] = rootY;
            }
            else
            {
                _root[rootY] = rootX;
                _rank[rootX]++;
            }

            return true;
        }
    }

    public int MinCostConnectPoints(int[][] points) {
        var uf = new UnionFind(points);
        return uf.Calc();
    }
}