import java.util.*;

// TL

class Solution {
    public boolean validPath(int n, int[][] edges, int source, int destination) {
        if (edges.length == 0) {
            return true;
        }

        List<List<Integer>> vertexToEdges = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            vertexToEdges.add(new ArrayList<>());
        }

        Queue<Integer> q = new LinkedList<>();
        for (int i = 0; i < edges.length; i++) {
            var a = edges[i][0];
            var b = edges[i][1];


            vertexToEdges.get(a).add(i);
            vertexToEdges.get(b).add(i);

            // edges from source
            if (a == source || b == source) {
                q.offer(i);
            }
        }

        var isEdgeVisited = new boolean[edges.length];
        var isVertexVisited = new boolean[n];

        while (!q.isEmpty()) {
            var currentEdgeIndex = q.poll();
            isEdgeVisited[currentEdgeIndex] = true;
            var currentEdge = edges[currentEdgeIndex];

            var currentEdgeSource = currentEdge[0];
            var currentEdgeDestination = currentEdge[1];

            isVertexVisited[currentEdgeSource] = true;
            isVertexVisited[currentEdgeDestination] = true;

            for (var x: vertexToEdges.get(currentEdgeSource)) {
                if (!isEdgeVisited[x]) {
                    isEdgeVisited[x] = true;
                    q.offer(x);
                }
            }
            for (var x: vertexToEdges.get(currentEdgeDestination)) {
                if (!isEdgeVisited[x]) {
                    isEdgeVisited[x] = true;
                    q.offer(x);
                }
            }
        }


        return isVertexVisited[destination];
    }
}