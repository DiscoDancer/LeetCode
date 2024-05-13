public class Solution {
    // 2 uf, == and !=
    // if controversary, then false

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

        var notEqualsTable = new bool[26,26];
        var lettersVisited = new bool[26];

        foreach (var equation in equations) {
            var a = equation[0] - 'a';
            var b = equation[3] - 'a';
            if (equation[1] == '=') {
                ufEquals.Union(a,b);
            }
            else {
                if (a == b) {
                    return false;
                }
                notEqualsTable[a,b] = true;
                notEqualsTable[b,a] = true;
            }
            lettersVisited[a] = true;
            lettersVisited[b] = true;
        }

        // ищем противоречения, мб можно искать и сразу
        for (int i = 0; i < 26; i++) {
            for (int j = 0; j < 26; j++) {
                if (i == j) continue;
                if (!lettersVisited[i] || !lettersVisited[j]) continue;

                var rootI = ufEquals.Find(i);
                var rootJ = ufEquals.Find(j);

                if (rootI != rootJ) continue;

                if (notEqualsTable[i,j]) return false;
            } 
        }

        return true;
    }
}