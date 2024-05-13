// editorial
public class Solution {

    public class UnionFind {
        private int[] _root;
        private int[] _rank;

        public UnionFind() {
            _root = new int[26];
            _rank = new int[26];

            for (int i = 0; i < 26; i++) {
                _root[i] = i;
                _rank[i] = 1;
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

            if (_rank[rootX] < _rank[rootY]) {
                _root[rootX] = rootY;
            }
            else if (_rank[rootX] > _rank[rootY]) {
                _root[rootY] = rootX;
            }
            else {
                _root[rootY] = rootX;
                _rank[rootX]++;
            }
        }
    }

    public bool EquationsPossible(string[] equations) {
        var ufEquals = new UnionFind();

        foreach (var equation in equations) {
            if (equation[1] == '=') {
                var a = equation[0] - 'a';
                var b = equation[3] - 'a';
                if (a == b) continue;
                
                ufEquals.Union(a,b);
            }
        }
        
        foreach (var equation in equations) {
            if (equation[1] == '!') {
                var a = equation[0] - 'a';
                var b = equation[3] - 'a';
                if (ufEquals.Find(a) == ufEquals.Find(b)) return false;
            }
        }

        return true;
    }
}