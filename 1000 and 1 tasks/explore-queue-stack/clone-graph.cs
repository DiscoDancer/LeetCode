public class Solution {
    // табличка как в сериализации
    // нужно копировать обходом


    // нужна табличка, чтобы не копировать 2 раза
    // мб еще visited добавить или просто DFS
    private Dictionary<Node, Node> tableClones = new();
    private HashSet<Node> _visited = new ();
    
    public Node CloneGraph(Node node) {
        if (node == null) {
            return null;
        }


        Node newNode;
        if (tableClones.ContainsKey(node)) {
            newNode = tableClones[node];
        }
        else {
            newNode = new Node(node.val);
            tableClones[node] = newNode;
        }

        
        if (_visited.Contains(node)) {
            return newNode;
        }
        _visited.Add(node);

        foreach (var child in node.neighbors) {
            newNode.neighbors.Add(CloneGraph(child));
        }

        return newNode;
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
