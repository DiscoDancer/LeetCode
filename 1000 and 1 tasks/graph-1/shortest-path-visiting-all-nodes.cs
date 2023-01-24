public class Solution {
    private int[][] cache;
    private int endingMask;

// https://leetcode.com/problems/shortest-path-visiting-all-nodes/solutions/1745489/shortest-path-visiting-all-nodes/?envType=study-plan&id=graph-i
    public int dp(int node, int mask, int[][] graph) {
        if (cache[node][mask] != 0) {
            return cache[node][mask];
        }

        if ((mask & (mask - 1)) == 0) {
            // Base case - mask only has a single "1", which means
            // that only one node has been visited (the current node)
            return 0;
        }

        cache[node][mask] = int.MaxValue - 1;
        foreach (var neighbor in graph[node]) {
            if ((mask & (1 << neighbor)) != 0) {
                int alreadyVisited = dp(neighbor, mask, graph);
                int notVisited = dp(neighbor, mask ^ (1 << node), graph);
                int betterOption = Math.Min(alreadyVisited, notVisited);
                cache[node][mask] = Math.Min(cache[node][mask], 1 + betterOption);
            }
        }

        return cache[node][mask];
    }

    public int ShortestPathLength(int[][] graph) {
        int n = graph.Length;
        endingMask = (1 << n) - 1;
        cache = new int[n + 1][];
        for (int i = 0; i < cache.Length; i++) {
            cache[i] = new int[endingMask + 1];
        }
        
        int best = int.MaxValue;
        for (int node = 0; node < n; node++) {
            best = Math.Min(best, dp(node, endingMask, graph));
        }
        
        return best;
    }
}