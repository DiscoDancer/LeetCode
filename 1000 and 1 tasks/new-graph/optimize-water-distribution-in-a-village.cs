public class Solution {
    public class UnionFind {
        public int[] _root;
        public int[] _minWell;
        public int[] _pipeCost;

        public UnionFind(int n, int[] wells) {
            _root = new int[n];
            _minWell = new int[n];
            _pipeCost = new int[n];

            for (var i = 0; i < n; i++) {
                _root[i] = i;
                _minWell[i] = wells[i];
            }
        }

        public int Find(int x){
            if (x == _root[x]) {
                return x;
            }

            _root[x] = Find(_root[x]);

            return _root[x];
        }

        public void Union(int x, int y, int c) {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX == rootY) {
                return;
            }
            

            if (_minWell[rootX] <= _minWell[rootY]) {
                _root[rootY] = rootX;
                
                _minWell[rootX] = Math.Min(_minWell[rootX], _minWell[rootY]);
                _pipeCost[rootX] = _pipeCost[rootX] + _pipeCost[rootY] + c;
            }
            else {
                _root[rootX] = rootY;
                
                _minWell[rootY] = Math.Min(_minWell[rootX], _minWell[rootY]);
                _pipeCost[rootY] = _pipeCost[rootX] + _pipeCost[rootY] + c;
            }
        }
    }

    public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes)
    {
        var uf = new UnionFind(n, wells);

        var pq = new PriorityQueue<(int x, int y, int c), int>();
        foreach (var xyc in pipes)
        {
            var x = xyc[0] - 1;
            var y = xyc[1] - 1;
            var c = xyc[2];
            pq.Enqueue((x, y, c), c);
        }

        while (pq.Count > 0)
        {
            var (x, y, c) = pq.Dequeue();

            var rootX = uf.Find(x);
            var rootY = uf.Find(y);

            // уже соединены
            if (rootX == rootY)
            {
                continue;
            }

            var costX = uf._minWell[rootX] + uf._pipeCost[rootX];
            var costY = uf._minWell[rootY] + uf._pipeCost[rootY];

            if (costX + costY > c + uf._minWell[rootX] + uf._pipeCost[rootX] + uf._pipeCost[rootY])
            {
                uf.Union(rootX, rootY, c);
            }
            if (costX + costY > c + uf._minWell[rootY] + uf._pipeCost[rootY] + uf._pipeCost[rootX])
            {
                uf.Union(rootX, rootY, c);
            }
        }

        // forced update
        for (int i = 0; i < n; i++)
        {
            uf.Find(i);
        }

        return uf._root.Distinct().Select(x => uf._minWell[x] + uf._pipeCost[x]).Sum();
    }
}