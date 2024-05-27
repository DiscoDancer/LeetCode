public class Solution {
    // минимальное остовное дерево
    // union find или лапками
    // unionf find + sort edges

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

    public int MinimumCost(int n, int[][] connections) {
        var uf = new UnionFind(n);

        var queue = new PriorityQueue<(int x, int y, int c), int>();
        foreach (var xyc in connections) {
            var x = xyc[0] - 1;
            var y = xyc[1] - 1;
            var c = xyc[2];
            queue.Enqueue((x,y,c), c);
        }

        var unitedCount = 1;
        var result = 0;

        while (unitedCount != n && queue.Count > 0) {
            var (x,y,c) = queue.Dequeue();

            var rootX = uf.Find(x);
            var rootY = uf.Find(y);

            if (rootX != rootY) {
                result += c;
                uf.Union(rootX, rootY);
                unitedCount++;
            }
        }

        return unitedCount == n ? result : -1;
    }
}