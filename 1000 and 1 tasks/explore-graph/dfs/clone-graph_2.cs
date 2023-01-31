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


// мб можно совсем тупо копирнуть?
// да, можно сначала таблицу смежности построить

public class Solution {
    private HashSet<int> _visited = new ();
    private Dictionary<Node, Node> _adjacencyTable = new ();

    // просто DFS обход
    // добавил заполнение таблицы связности
    private void StupidDFS(Node node) {
        if (_visited.Contains(node.val)) {
            return;
        }

        if (!_adjacencyTable.ContainsKey(node)) {
            _adjacencyTable[node] = new Node(node.val);
        }

        _visited.Add(node.val);

        foreach (var n in node.neighbors) {
            if (!_visited.Contains(n.val)) {
                StupidDFS(n);
            }
            if (!_adjacencyTable.ContainsKey(n)) {
                _adjacencyTable[n] = new Node(n.val);
            }

            _adjacencyTable[node].neighbors.Add(_adjacencyTable[n]);
        }
    }

    public Node CloneGraph(Node node) {
        if (node == null) {
            return null;
        }

        StupidDFS(node);

        return _adjacencyTable[node];
    }
}