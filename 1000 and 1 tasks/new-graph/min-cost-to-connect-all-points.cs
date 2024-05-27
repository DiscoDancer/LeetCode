// копипаста от сюда connecting-cities-with-minimum-cost

public class Solution {
    public class UnionFind {
        private int[] _rank;
        private int[] _root;

        public UnionFind(int n){
            _rank = new int[n];
            _root = new int[n];

            for (int i = 0; i < n; i++) {
                _rank[i] = 0;
                _root[i] = i;
            }
        }

        public int Find(int x) {
            if (x == _root[x]) {
                return x;
            }

            _root[x] = Find(_root[x]);

            return _root[x];
        }

        public bool Union(int x, int y) {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX == rootY) {
                return false;
            }

            if (_rank[rootX] > _rank[rootY]) {
                _root[rootY] = rootX;
            }
            else if (_rank[rootX] < _rank[rootY]) {
                _root[rootX] = rootY;
            }
            else {
                _root[rootY] = rootX;
                _rank[rootX]++;
            }

            return true;
        }
    }

    public int MinCostConnectPoints(int[][] points) {
        var n = points.Length;
        var uf = new UnionFind(n);

        var queue = new PriorityQueue<(int x, int y, int d), int>();

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                var dist = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                queue.Enqueue((i,j,dist), dist);
            }
        }

        var unitedCount = 1;
        var result = 0;

        while (unitedCount != n && queue.Count > 0) {
            var (x,y,d) = queue.Dequeue();

            var rootX = uf.Find(x);
            var rootY = uf.Find(y);

            if (rootX != rootY) {
                result += d;
                uf.Union(rootX, rootY);
                unitedCount++;
            }
        }

        return unitedCount == n ? result : -1;
    }
}