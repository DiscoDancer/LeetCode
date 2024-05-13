public class Solution {
    // упрощенное решение из satisfiability-of-equality-equations
    public class UnionFind {

        private int[] _root;

        public UnionFind() {
            _root = new int[26];

            for (int i = 0; i < 26; i++) {
                _root[i] = i;
            }
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

            if (rootX < rootY) {
                _root[rootY] = rootX;
            }
            else {
                 _root[rootX] = rootY;
            }
        }
    }

    public string SmallestEquivalentString(string s1, string s2, string baseStr) {
        var sb = new StringBuilder();
        var uf = new UnionFind();

        for (int i = 0; i < s1.Length; i++) {
            var a = s1[i] - 'a';
            var b = s2[i] - 'a';

            uf.Union(a,b);
        }

        foreach (var c in baseStr) {
            sb.Append(  (char)(uf.Find(c-'a') + 'a') );
        }

        return sb.ToString();
    }
}