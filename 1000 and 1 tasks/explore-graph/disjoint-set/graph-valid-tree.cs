public class Solution {
    private static int _count;

    public class UnionFind {
        public int[] _rank;
        public int[] _root;

        public UnionFind(int n) {
            _rank = new int[n];
            _root = new int[n];

            for (int i = 0; i < n; i++) {
                _rank[i] = 1;
                _root[i] = i;
            }

            _count = n;
        }

        public int Find(int x) {
            if (_root[x] == x) {
                return x;
            }

            _root[x] = Find(_root[x]);
            return _root[x];
        }

        public void Union(int x, int y) {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX == rootY) {
                return;
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

             _count--;
        }

        public bool AreConnected(int x, int y) {
            return Find(x) == Find(y);
        }
    }

    public bool ValidTree(int n, int[][] edges) {
        if (edges.Length != n - 1) {
            return false;
        }

        var uf = new UnionFind(n);
        foreach (var e in edges) {
            uf.Union(e[0], e[1]);
        }

        return _count == 1;
    }
}