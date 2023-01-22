public class Solution {
    // количество островов можно найти, это будет сколько требуется
    // вопрос - как найти сколько имеется = найти количество мостиков в группе
    // вычитаем и профит
    public int MakeConnected(int n, int[][] connections) {
        var islands = 0;
        var spareBridges = 0;
        var N = n;
        var visited = new bool[N];
        var neighbours = new List<int>[N]; 
        var startingBridges = new int[N];
        foreach (var connection in connections) {
            startingBridges[connection[0]]++;

            if (neighbours[connection[0]] == null) {
                neighbours[connection[0]] = new List<int>();
            }

            if (neighbours[connection[1]] == null) {
                neighbours[connection[1]] = new List<int>();
            }

            neighbours[connection[0]].Add(connection[1]);
            neighbours[connection[1]].Add(connection[0]);
        }

        

        for (int i = 0; i < N; i++)
        {
            if (visited[i])
            {
                continue;
            }

            var queue = new Queue<int>();
            queue.Enqueue(i);
            visited[i] = true;

            var bridgeCount = 0;
            var nodesCount = 0;
            
            while (queue.Any())
            {
                var cur = queue.Dequeue();
                nodesCount++;
                bridgeCount += startingBridges[cur];

                if (neighbours[cur] == null) {
                    continue;
                }

                foreach (var neighbour in neighbours[cur]) {
                    if (!visited[neighbour]) {
                        queue.Enqueue(neighbour);
                        visited[neighbour] = true;
                    }
                }
            }

            spareBridges += Math.Max(0, bridgeCount - (nodesCount - 1));

            islands++;
        }

        if (spareBridges >= islands - 1)
        {
            return islands - 1;
        }

        return -1;
    }
}