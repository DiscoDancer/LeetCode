import java.util.*;


class Solution {
    public int reachableNodes(int n, int[][] edges, int[] restricted) {
        List<Integer>[] arr = new List[n];
        for (int i = 0; i < n; i++) {
            arr[i] = new ArrayList<>();
        }


        var isRestricted  = new boolean[n];
        for (var r: restricted) {
            isRestricted[r] = true;
        }

        for (var e: edges) {
            var a = e[0];
            var b = e[1];

            if (isRestricted[a] || isRestricted[b]) {
                continue;
            }

            arr[a].add(b);
            arr[b].add(a);
        }

        var visited = new boolean[n];
        visited[0] = true;

        var queue = new ArrayDeque<Integer>();
        queue.add(0);

        while (!queue.isEmpty()) {
            var node = queue.poll();

            for (var i: arr[node]) {
                if (!visited[i]) {
                    visited[i] = true;
                    queue.add(i);
                }
            }
        }

        var result = 0;
        for (int i = 0; i < n; i++) {
            if (visited[i]) {
                result++;
            }
        }

        return result;
    }
}