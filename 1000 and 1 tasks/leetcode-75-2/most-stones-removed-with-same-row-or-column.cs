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

    public int RemoveStones(int[][] stones) {
        var stonesCount = stones.Length;
        var uf = new UnionFind(stonesCount);

        // 0 row -> indexes of stones
        var rowsTable = new Dictionary<int, List<int>>();
        var colsTable = new Dictionary<int, List<int>>();

        for (var i = 0; i < stones.Length; i++) {
            var stone = stones[i];
            if (!rowsTable.ContainsKey(stone[0])) {
                rowsTable[stone[0]] = new ();
            }
            rowsTable[stone[0]].Add(i);
            if (!colsTable.ContainsKey(stone[1])) {
                colsTable[stone[1]] = new ();
            }
            colsTable[stone[1]].Add(i);
        }

        for (int i = 0; i < stones.Length; i++) {
            var stone = stones[i];
            foreach (var j in rowsTable[stone[0]]) {
                if (i != j) {
                    uf.Union(i,j);
                }
            }
            foreach (var j in colsTable[stone[1]]) {
                if (i != j) {
                    uf.Union(i,j);
                }
            }
        }

        for (int i = 0; i < stones.Length; i++) {
            uf.Find(i);
        }

        var groupsCount = uf._root.Distinct().Count();
        return stonesCount - groupsCount;
    }
}