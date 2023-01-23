public class Solution {
    // nodes 0..n-1
    // directed
    // graph[i] = список от i к другим (может быть пустым)
    // terminal node if there are no outgoing edges.
    // safe node if every possible path starting from that node leads to a terminal node (or another safe node).

    // можно завести список наборот, кто ссылается на node
    // пузырьковой сортировкой отмечать safe или DFS(ом)
    // те, кто пустой = safe
    public IList<int> EventualSafeNodes(int[][] graph) {
        // ключа может не быть
        var incomingTable = new Dictionary<int, List<int>>();

        var terminal = new bool[graph.Length];
        var visited = new bool[graph.Length];

        var queue = new Queue<int>();

        for (int i = 0; i < graph.Length; i++) {
            if (graph[i].Length == 0) {
                queue.Enqueue(i);
                // terminal[i] = true;
                visited[i] = true;
                continue;
            }
            for (int j = 0; j < graph[i].Length; j++) {
                if (!incomingTable.ContainsKey(graph[i][j])) {
                    incomingTable[graph[i][j]] = new List<int>(); 
                }
                incomingTable[graph[i][j]].Add(i);
            }
        }

        while (queue.Any()) {
            var x = queue.Dequeue();
            terminal[x] = true;

            if (!incomingTable.ContainsKey(x)) {
                continue;
            }

            foreach (var y in incomingTable[x]) {
                if (!visited[y])
                {
                    var outgoing = graph[y];
                    var allTerm = true;
                    for (int k = 0; k < outgoing.Length; k++)
                    {
                        allTerm = allTerm && terminal[outgoing[k]];
                    }

                    if (allTerm)
                    {
                        visited[y] = true;
                        queue.Enqueue(y);
                    }
                }
            }
        }

        var res = new List<int>();
        for (int i = 0; i < terminal.Length; i++) {
            if (terminal[i]) {
                res.Add(i);
            }
        }

        return res;
    }
}