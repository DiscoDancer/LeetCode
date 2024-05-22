// editorial
public class Solution {
    public int LargestPathValue(string colors, int[][] edges) {
        var n = colors.Length;
        var adj = new Dictionary<int, List<int>>();
        var indegree = new int[n];

        // a -> b
        foreach (var ab in edges) {
            var a = ab[0];
            var b = ab[1];
            if (!adj.ContainsKey(a)) {
                adj[a] = new ();
            }
            adj[a].Add(b);
            indegree[b]++;
        }

        var count = new int[n,26];
        var q = new Queue<int>();

        for (int i = 0; i < n; i++) {
            if (indegree[i] == 0) {
                q.Enqueue(i);
            }
        }

        var answer = 1;
        var nodesSeen = 0;

        while (q.Any()) {
            var node = q.Dequeue();
            answer = Math.Max(answer, ++count[node,colors[node] - 'a']);
            nodesSeen++;

            if (!adj.ContainsKey(node)) {
                continue;
            }

            foreach (var neighbor in adj[node]) {
                for (int i = 0; i < 26; i++) {
                    // Try to update the frequency of colors for the neighbor to include paths
                    // that use node->neighbor edge.
                    // если понятно, то мы делаем propogate максимальное количество по цвету от листов
                    count[neighbor, i] = Math.Max(count[neighbor, i], count[node, i]);
                }
                indegree[neighbor]--;
                if (indegree[neighbor] == 0) {
                    q.Enqueue(neighbor);
                }
            }
        }

        return nodesSeen < n ? -1 : answer;
    }
}