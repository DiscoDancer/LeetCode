import java.util.*;


class Solution {
    public int countComponents(int n, int[][] edges) {
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

        var nextIslandNumber = 0;
        var minorIslandMap = new int[n];

        for (var i = 0; i < n; i++) {
            // lets visit
            if (minorIslandMap[i] == 0) {
                nextIslandNumber++;
                
                Queue<Integer> q = new LinkedList<>();
                q.offer(i);
                minorIslandMap[i] = nextIslandNumber;
                
                while (!q.isEmpty()) {
                    var curVertex = q.poll();
                    for (var ei : vertexToEdges.get(curVertex)) {
                        var edge = edges[ei];
                        var a = edge[0];
                        var b = edge[1];
                        
                        if (minorIslandMap[a] == 0) {
                            q.offer(a);
                        }
                        if (minorIslandMap[b] == 0) {
                            q.offer(b);
                        }

                        minorIslandMap[a] = nextIslandNumber;
                        minorIslandMap[b] = nextIslandNumber;
                    }
                }
            }
        }


        return nextIslandNumber;
    }
}