import java.util.*;


class Solution {
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
        }

        public int Find(int x) {
            if (x == _root[x]) {
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
        }
    }


    public int countComponents(int n, int[][] edges) {
        var uf = new UnionFind(n);

        for (var edge : edges) {
            uf.Union(edge[0], edge[1]);
        }

        var table = new boolean[n];

        for (int i = 0; i < n; i++) {
            uf.Find(i);
            table[uf._root[i]] = true;
        }

        var result = 0;
        for (int i = 0; i < n; i++) {
            if (table[i]) {
                result++;
            }
        }

        return result;
    }
}