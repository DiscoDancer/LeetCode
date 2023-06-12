
public class Solution {
    private Dictionary<Node, Node> tableClones = new();

    public Node CloneGraph(Node node) {
        if (node == null)
        {
            return null;
        }

        // 2 BFS fill table + fill connections
        var queue = new Queue<Node>();
        queue.Enqueue(node);
        tableClones[node] = new Node(node.val);

        while (queue.Any()) {
            var curNode = queue.Dequeue();
            foreach (var child in curNode.neighbors) {
                if (!tableClones.ContainsKey(child)) {
                    tableClones[child] = new Node(child.val);
                    queue.Enqueue(child);
                }
                 tableClones[curNode].neighbors.Add(tableClones[child]);
            }
        }

        return tableClones[node];
    }
}

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/