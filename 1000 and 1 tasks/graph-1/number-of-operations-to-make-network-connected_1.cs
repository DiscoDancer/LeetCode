public class Solution {
    // количество островов можно найти, это будет сколько требуется
    // вопрос - как найти сколько имеется = найти количество мостиков в группе
    // вычитаем и профит
    public int MakeConnected(int n, int[][] connections) {
        var islands = 0;
        var spareBridges = 0;
        var N = n;
        var visited = new bool[N];

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

                foreach (var connection in connections)
                {
                    if (connection[0] == cur) {
                        bridgeCount++;
                    }

                    if (connection[0] == cur && !visited[connection[1]])
                    {
                        queue.Enqueue(connection[1]);
                        visited[connection[1]] = true;
                    }

                    if (connection[1] == cur && !visited[connection[0]])
                    {
                        queue.Enqueue(connection[0]);
                        visited[connection[0]] = true;
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