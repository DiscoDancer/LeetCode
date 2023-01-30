public class Solution {
    // people 0..n-1
    // [timestampi, xi, yi] xi and yi will be friends at the time timestampi

    public static int _count = 0;

    public class UnionFind {
        private int[] _rank;
        private int[] _root;

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

    // взять все время отсортировать, добавлять по одному и проверять count
    public int EarliestAcq(int[][] logs, int n) {
        var queue = new PriorityQueue<(int x, int y), int>();

        foreach (var l in logs) {
            queue.Enqueue((l[1], l[2]), l[0]);
        }

        var uf = new UnionFind(n);

        while (queue.TryDequeue(out var cur, out var t)) {
            uf.Union(cur.x, cur.y);
            if (_count == 1) {
                return t;
            }
        }

        return -1;
    }
}