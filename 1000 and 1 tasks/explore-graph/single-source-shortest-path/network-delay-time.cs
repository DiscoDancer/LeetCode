public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var adjacencyList = new Dictionary<int, List<(int v, int d)>>();
        foreach (var t in times) {
            var from = t[0]-1;
            var to = t[1]-1;
            var d = t[2];
            if (!adjacencyList.ContainsKey(from)) {
                adjacencyList[from] = new ();
            }
            adjacencyList[from].Add((to,d));
        }

        var distanceFromKTable = new int[n];
        Array.Fill(distanceFromKTable, int.MaxValue);
        
        var queue = new PriorityQueue<int, int>();

        // start
        queue.Enqueue(k-1, 0);
        distanceFromKTable[k-1] = 0;

        while (queue.TryDequeue(out var vertex, out var distanceToVertex)) {
            // получили результат хуже, чем уже есть
            if (distanceToVertex > distanceFromKTable[vertex]) {
                continue;
            }

            // некуда идти из текущей
            if (!adjacencyList.ContainsKey(vertex)) {
                continue;
            }

            foreach (var (neigbour, distanceToNeighbour) in adjacencyList[vertex]) {
                if (distanceFromKTable[neigbour] > distanceToVertex + distanceToNeighbour) {
                    distanceFromKTable[neigbour] = distanceToVertex + distanceToNeighbour;
                    queue.Enqueue(neigbour, distanceFromKTable[neigbour]);
                }
            }
        }

        var max = distanceFromKTable.Max();
        return max == int.MaxValue ? -1 : max;
    }
}