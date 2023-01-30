public class Solution {
    // equations[i] = [Ai, Bi] and values[i] represent the equation Ai / Bi = values[i]
    // queries[j] = [Cj, Dj]
    // Return the answers to all queries or -1.0


    /*
        Идеи:
        - строим также группы (острова), вместо массива словари
        - каждый элемент переводить в корни
        - будет f(x) = Y*root
        - если не в одном root -> return -1
        - можно сначала прочитать и забить их
    */

    // TODO построить просто группы

    public class UnionFind {
        public Dictionary<string, (string node, double coef)> _root = new ();

        public UnionFind(IList<IList<string>> equations) {
            foreach (var e in equations) {
                if (!_root.ContainsKey(e.First())) {
                    _root[e.First()] = (e.First(), 1.0);
                }
                if (!_root.ContainsKey(e.Last())) {
                    _root[e.Last()] = (e.Last(), 1.0);
                }
            }
        }

        public (string node, double coef) Find(string x) {
            if (x == _root[x].node) {
                return _root[x];
            }


            var cur = _root[x];
            while (cur.node != _root[cur.node].node) {
                cur = (_root[cur.node].node, cur.coef *_root[cur.node].coef);
            }

            return cur;
        }

        public void Union(string x, string y, double coef) {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX.node == rootY.node) {
                return;
            }

            _root[rootX.node] = (rootY.node, coef * rootY.coef / rootX.coef);
        }

        public bool AreConnected(string x, string y) {
            return Find(x) == Find(y);
        }
    }

    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        var uf = new UnionFind(equations);

        for (int i = 0; i < equations.Count(); i++) {
            uf.Union(equations[i][0], equations[i][1], values[i]);
        }

        var res = new double[queries.Count()];
        for (int i = 0; i < queries.Count(); i++) {
            var query = queries[i];
            if (!uf._root.ContainsKey(query.First()) || !uf._root.ContainsKey(query.Last())) {
                res[i] = -1.0;
            }
            else {
                var f1 = uf.Find(query.First());
                var f2 = uf.Find(query.Last());
                if (f1.node != f2.node) {
                    res[i] = -1.0;
                }
                else {
                    res[i] = f1.coef / f2.coef;
                }
            }
        }

        return res;
    }
}