// editorial
public class Solution {
    // предполагаем что MST размножаются из-за неоднозначности сортировки ребер
    // решением в лоб может быть копирование UF на каждую неоднозначность
    // какой нибудь backtracking может нас всех спасти
    
    public class UnionFind
    {
        public int[] _rank;
        public int[] _root;

        public UnionFind(int n)
        {
            _rank = new int [n];
            _root = new int [n];

            for (int i = 0; i < n; i++)
            {
                _rank[i] = 0;
                _root[i] = i;
            }
        }

        public int Find(int x)
        {
            if (x == _root[x])
            {
                return x;
            }

            _root[x] = Find(_root[x]);
            return _root[x];
        }

        public bool Union(int x, int y)
        {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX == rootY)
            {
                return false;
            }

            if (_rank[rootX] < _rank[rootY])
            {
                _root[rootX] = rootY;
            }
            else if (_rank[rootX] > _rank[rootY])
            {
                _root[rootY] = rootX;
            }
            else
            {
                _root[rootY] = rootX;
                _rank[rootX]++;
            }

            return true;
        }
    }

    private static int GetBestMst(int n, int[][] sortedEdges)
    {
        var mstSum = 0;
        var connectedCount = 1;
        var sortedEdgesIndex = 0;
        var uf = new UnionFind(n);
        while (connectedCount < n && sortedEdgesIndex < sortedEdges.Length)
        {
            var edge = sortedEdges[sortedEdgesIndex];
            
            var x = edge[0];
            var y = edge[1];
            var cost = edge[2];
            if (uf.Union(x, y))
            {
                connectedCount++;
                mstSum += cost;
            }
            sortedEdgesIndex++;
        }

        return mstSum;
    }
    
    public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges)
    {
        var sortedEdges = edges
            .Select((x, i) => new[] {x[0], x[1], x[2], i})
            .OrderBy(x => x[2])
            .ToArray();
        
        // нашли самую лучшую mst (потому что без ограничений)
        // остальные должны быть с такой же суммой, чтобы считаться mst
        var bestMst = GetBestMst(n, sortedEdges);

        var critical = new List<int>();
        var nonCritical = new List<int>();

        for (var iEdge = 0; iEdge < sortedEdges.Length; iEdge++)
        {
            var uf = new UnionFind(n);
            // пробуем строить без реба
            var connectedCount = 1;
            var mstSum = 0;
            for (var jEdge = 0; jEdge < sortedEdges.Length && connectedCount < n; jEdge++)
            {
                if (jEdge == iEdge) continue;
                
                var edge = sortedEdges[jEdge];
            
                var x = edge[0];
                var y = edge[1];
                var cost = edge[2];
                if (uf.Union(x, y))
                {
                    connectedCount++;
                    mstSum += cost;
                }
            }
            
            // построили
            // если увеличился или порвался
            if (mstSum > bestMst || connectedCount < n)
            {
                // под 3 спрятан оригинальный индекс
                critical.Add(sortedEdges[iEdge][3]);
            }
            // заставляем строиться с ребром i
            else
            {
                uf = new UnionFind(n);
                uf.Union(sortedEdges[iEdge][0], sortedEdges[iEdge][1]);
                connectedCount = 2;
                mstSum = sortedEdges[iEdge][2];

                for (var jEdge = 0; jEdge < sortedEdges.Length && connectedCount < n; jEdge++)
                {   if (jEdge == iEdge) continue;
                
                    var edge = sortedEdges[jEdge];
            
                    var x = edge[0];
                    var y = edge[1];
                    var cost = edge[2];
                    if (uf.Union(x, y))
                    {
                        connectedCount++;
                        mstSum += cost;
                    }
                }

                if (mstSum == bestMst)
                {
                    nonCritical.Add(sortedEdges[iEdge][3]);
                }
            }
        }
        
        return [critical, nonCritical];
    }
}