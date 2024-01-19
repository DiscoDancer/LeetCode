public class Solution {
        public class UnionFind
    {
        int[] parent;
        int[] rank;
        int count;
        
        public UnionFind(int size) {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++)
                parent[i] = -1;
            count = 0;
        }
        
        
        public void addLand(int x) {
            if (parent[x] >= 0)
                return;
            parent[x] = x;
            count++;
        }
        
        public bool isLand(int x)
        {
            return parent[x] >= 0;
        }
        
        public int numberOfIslands() {
            return count;
        }
        
        public int find(int x) {
            if (parent[x] != x)
                parent[x] = find(parent[x]);
            return parent[x];
        }
        
        public void union(int x, int y) {
            int xset = find(x), yset = find(y);
            if (xset == yset) {
                return;
            } else if (rank[xset] < rank[yset]) {
                parent[xset] = yset;
            } else if (rank[xset] > rank[yset]) {
                parent[yset] = xset;
            } else {
                parent[yset] = xset;
                rank[xset]++;
            }
            count--;
        }
    }

    public IList<int> NumIslands2(int m, int n, int[][] positions) {
         var x = new int[]{ -1, 1, 0, 0 };
        var y = new []{ 0, 0, -1, 1 };
        UnionFind dsu = new UnionFind(m * n);
        var answer = new List<int>();
        
        foreach (var position in positions) {
            int landPosition = position[0] * n + position[1];
            dsu.addLand(landPosition);

            for (int i = 0; i < 4; i++) {
                int neighborX = position[0] + x[i];
                int neighborY = position[1] + y[i];
                int neighborPosition = neighborX * n + neighborY;
                // If neighborX and neighborY correspond to a point in the grid and there is a
                // land at that point, then merge it with the current land.
                if (neighborX >= 0 && neighborX < m && neighborY >= 0 && neighborY < n &&
                    dsu.isLand(neighborPosition)) {
                    dsu.union(landPosition, neighborPosition);
                }
            }
            answer.Add(dsu.numberOfIslands());
        }
        return answer;
    }
}