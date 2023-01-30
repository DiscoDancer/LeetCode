public class Solution {
    // находим острова букв
    // размечаем строку отсровами
    // сортируем острова
    // вписываем новую строку

    public class UnionFind {
        private int[] _rank;
        private int[] _root;

        public UnionFind(int n) {
            _rank = new int[n];
            _root = new int[n];

            for (int i = 0; i < n; i++) {
                _rank[i] = 1;
                _root[i] = i;
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
            var rootX = Find(x);
            var rootY = Find(y);

            if (_rank[rootX] > _rank[rootY]) {
                _root[rootY] = rootX;
            }
            else if (_rank[rootX] < _rank[rootY]) {
                 _root[rootX] = rootY;
            }
            else {
                _root[rootY] = rootX;
                _rank[rootX]++;
            }
        }

        public bool AreConnected(int x, int y) {
            return Find(x) == Find(y);
        }
    }

    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs) {
        var N = s.Length;
        var uf = new UnionFind(N);

        foreach (var p in pairs) {
            uf.Union(p.First(), p.Last());
        }

        var groups = new Dictionary<int, (List<int> i, List<char> c)>();

        for (int i = 0; i < N; i++) {
            var found = uf.Find(i);
            if (!groups.ContainsKey(found)) {
                groups[found] = (new List<int>(), new List<char>());
            }
            var (iList, cList) = groups[found];
            iList.Add(i);
            cList.Add(s[i]);
        }

        var resArr = new char[N];

        foreach (var k in groups.Keys) {
            var (iList, cList) = groups[k];
            var cListSorted = cList.OrderBy(x => x).ToArray();

            for (int i = 0; i < iList.Count(); i++) {
                 resArr[iList[i]] = cListSorted[i];
            }
        }

        return new string(resArr);
    }
}