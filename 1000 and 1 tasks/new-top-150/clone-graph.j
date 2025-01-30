/*
// Definition for a Node.
class Node {
    public int val;
    public List<Node> neighbors;
    public Node() {
        val = 0;
        neighbors = new ArrayList<Node>();
    }
    public Node(int _val) {
        val = _val;
        neighbors = new ArrayList<Node>();
    }
    public Node(int _val, ArrayList<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

import java.util.HashMap;
import java.util.HashSet;
import java.util.Queue;

class Solution {
    public Node cloneGraph(Node node) {
        if (node == null) {
            return null;
        }

        var table = new HashMap<Node, Node>();
        var visited = new HashSet<Node>();
        Queue<Node> queue = new java.util.LinkedList<>();

        queue.add(node);
        visited.add(node);

        while (!queue.isEmpty()) {
            var cur = queue.poll();
            var mapped = table.getOrDefault(cur, null);
            if (mapped == null) {
                mapped = new Node(cur.val);
                table.put(cur, mapped);
            }

            for (var neighbor : cur.neighbors) {
                var mappedNeighbor = table.getOrDefault(neighbor, null);
                if (mappedNeighbor == null) {
                    mappedNeighbor = new Node(neighbor.val);
                    table.put(neighbor, mappedNeighbor);
                }
                mapped.neighbors.add(mappedNeighbor);

                if (visited.add(neighbor)) {
                    queue.add(neighbor);
                }
            }
        }

        return table.get(node);
    }
}