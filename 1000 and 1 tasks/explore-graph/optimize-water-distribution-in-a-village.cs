public class Solution {

    // n houses: 1..n
    // можно построить колодец в доме, стоимость wells[i - 1] 0-based !
    // или можно построить pipe из другого дома pipes[j] = [house1j, house2j, costj] 1-based !
    // в один дома можно кучу труб протянуть

    /*
        Идеи:
        - разбить на острова
        - одиночные острова сразу выкинуть
        - внутри острова нужна таблица с кратчайшими путями
        - перебором втыкать колодцы (все варианты)
        - не очень понятно, как считать вариант с несколькими колодцами
        - а если начать с листика ?
        - Если все трубы в вершину >= ее подключения, то ее подключаем (суммируется с одиночн остров)
        - Но это может вообще ничего не покрыть
        - мб можно оптимально UF построить, где вес вместо rank ?

        Тупое решение:
        - разбиваем на острова
        - нужна матрица кратчайших путей для острова (Дейкстра)
        - для каждого острова считаем лучшее решение перебирая все варианты (1 колодец и тд)
    */

    // https://leetcode.com/problems/optimize-water-distribution-in-a-village/solutions/1301513/optimize-water-distribution-in-a-village/?orderBy=most_votes
    public class UnionFind{
        private int[] _root;
        private int[] _rank;

        public UnionFind(int n) {
            _root = new int[n + 1];
            _rank = new int[n + 1];

            for (int i = 0; i <= n; i++) {
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

        public bool Union(int x, int y) {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX == rootY) {
                return false;
            }

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

            return true;
        }
    }

    public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes) {
        var edgeQueue = new PriorityQueue<(int x, int y), int>();
        // add the virtual vertex (index with 0) along with the new edges.
        for (int i = 0; i < wells.Length; i++) {
            edgeQueue.Enqueue((0, i+1), wells[i]);
        }
        // add the existing edges
        for (int i = 0; i < pipes.Length; i++) {
            edgeQueue.Enqueue((pipes[i][0], pipes[i][1]), pipes[i][2]);
        }

        var uf = new UnionFind(n);
        int totalCost = 0;
        while (edgeQueue.TryDequeue(out var cur, out var c)) {
            var house1 = cur.x;
            var house2 = cur.y;
            var cost = c;

            if (uf.Union(house1, house2)) {
                totalCost += cost;
            }
        }

        return totalCost;
    }
}
