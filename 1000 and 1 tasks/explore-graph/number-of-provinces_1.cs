public class Solution {

    // https://leetcode.com/explore/learn/card/graph/618/disjoint-set/3846/

    private static int _count = 0;

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
            _count--;
        }
        
        public bool AreConnected(int x, int y) {
            return Find(x) == Find(y);
        }
    }

    public int FindCircleNum(int[][] isConnected) {
        var N = isConnected.Length;
        _count = N;
        var unionFind = new UnionFind(N);

        for (int i = 0; i < N; i++) {
            for (int j = i + 1; j < N; j++) {
                if (isConnected[i][j] == 1) {
                    unionFind.Union(i, j);
                } 
            }
        }

        return _count;
    }
}