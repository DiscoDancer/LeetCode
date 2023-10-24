public class Solution {
    public class UnionFind {
        public int[] _root;
        public int[] _rank;
            
        public UnionFind(int n) {
            _root = new int[n];
            _rank = new int[n];
            
            for (int i = 0; i < n; i++) {
                _root[i] = i;
                _rank[i] = 1;
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
            int rootX = Find(x);
            int rootY = Find(y);
            
            if (rootX == rootY) {
                return;
            }
            
            if (_rank[x] > _rank[y]) {
                _root[rootY] = rootX;
            }
            else if (_rank[x] < _rank[y]) {
                 _root[rootX] = rootY;
            } else {
                _root[rootY] = rootX;
                _rank[rootX] += 1;
            }
        }
        
        public bool AreConnected(int x, int y) {
            return Find(x) == Find(y);
        }
    }

    public int FindCircleNum(int[][] isConnected) {
        var uf = new UnionFind(isConnected.Length);
        for (int i = 0; i < isConnected.Length; i++) {
            for (int j = i + 1; j < isConnected.Length; j++) {
                if (isConnected[i][j] != 0) {
                    uf.Union(i, j);
                }
            }
        }
        
        for (int i = 0; i < isConnected.Length; i++) {
            uf.Find(i);
        }

        return uf._root.Distinct().Count();
    }
}