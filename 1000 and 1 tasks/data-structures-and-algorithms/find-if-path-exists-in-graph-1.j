import java.util.*;


class Solution {
    public boolean validPath(int n, int[][] edges, int source, int destination) {
        if (edges.length == 0) {
            return true;
        }

        List<List<Integer>> vertexToEdges = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            vertexToEdges.add(new ArrayList<>());
        }

        for (int i = 0; i < edges.length; i++) {
            var a = edges[i][0];
            var b = edges[i][1];

            vertexToEdges.get(a).add(i);
            vertexToEdges.get(b).add(i);
        }

        Queue<Integer> q = new LinkedList<>();


        var isVertexVisited = new boolean[n];

        q.offer(source);
        isVertexVisited[source] = true;

        while (!q.isEmpty()) {
            var currentVertex = q.poll();

            for (var ei : vertexToEdges.get(currentVertex)) {
                var a = edges[ei][0];
                var b = edges[ei][1];
                
                if (!isVertexVisited[a]) {
                    isVertexVisited[a] = true;
                    q.offer(a);
                }
                if (!isVertexVisited[b]) {
                    isVertexVisited[b] = true;
                    q.offer(b);
                }
            }
        }


        return isVertexVisited[destination];
    }
}