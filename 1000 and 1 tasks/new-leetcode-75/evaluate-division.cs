public class Solution {
    public class UnionFind {
        public Dictionary<string, string> _root;
        public Dictionary<string, int> _rank;
        public Dictionary<string, double> _toRootRation;
            
        public UnionFind(IList<IList<string>> equations) {
            _root = new();
            _rank = new();
            _toRootRation = new();
            
            for (int i = 0; i < equations.Count; i++)
            {
                var a = equations[i][0];
                var b = equations[i][1];

                if (!_rank.ContainsKey(a))
                {
                    _rank[a] = 1;
                    _root[a] = a;
                    _toRootRation[a] = 1.0;
                }
                if (!_rank.ContainsKey(b))
                {
                    _rank[b] = 1;
                    _root[b] = b;
                    _toRootRation[b] = 1.0;
                }
            }
        }
        
        public string Find(string x) {
            if (!_rank.ContainsKey(x)) {
                return null;
            }

            var p = x;
            var ratio = _toRootRation[p];

            while (p != _root[p])
            {
                p = _root[p];
                ratio *= _toRootRation[p];
            }

            _root[x] = p;
            _toRootRation[x] = ratio;

            return p;
        }
        
        public void Union(string x, string y, double v) {
            var rootX = Find(x);
            var rootY = Find(y);
            
            if (rootX == rootY) {
                return;
            }
            
            if (_rank[rootX] > _rank[rootY]) {
                _root[rootY] = rootX;
                _toRootRation[rootY] = _toRootRation[x] / v / _toRootRation[y];
            }
            else if (_rank[rootX] < _rank[rootY]) {
                _root[rootX] = rootY;
                _toRootRation[rootX] = _toRootRation[y] * v / _toRootRation[x];
            } else {
                _root[rootY] = rootX;
                _toRootRation[rootY] = _toRootRation[x] / v / _toRootRation[y];
                _rank[rootX] += 1;
            }
        }
        
        public bool AreConnected(string x, string y) {
            return Find(x) == Find(y);
        }
    }
    
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var uf = new UnionFind(equations);

        for (int i = 0; i < equations.Count; i++)
        {
            var a = equations[i][0];
            var b = equations[i][1];
            var v = values[i];
            
            uf.Union(a,b,v);
        }

        var results = new List<double>();
        foreach (var q in queries)
        {
            var a = q[0];
            var b = q[1];

            var aRoot = uf.Find(a);
            var bRoot = uf.Find(b);

            if (aRoot == null || bRoot == null || aRoot != bRoot)
            {
                results.Add(-1.0);
            }
            else
            {
                results.Add(uf._toRootRation[aRoot] * uf._toRootRation[a] / uf._toRootRation[bRoot] / uf._toRootRation[b]);
            }
        }

        return results.ToArray();
    }
}