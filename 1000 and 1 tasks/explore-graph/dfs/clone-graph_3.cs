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


// https://leetcode.com/problems/clone-graph/solutions/421214/clone-graph/?orderBy=most_votes

public class Solution {
    private Dictionary<Node, Node> _adjacencyTable = new ();

    // просто DFS обход
    // добавил заполнение таблицы связности
    private Node Clone(Node node) {
        if (_adjacencyTable.ContainsKey(node)) {
            return _adjacencyTable[node];
        }

        _adjacencyTable[node] = new Node(node.val);

        foreach (var n in node.neighbors) {
            _adjacencyTable[node].neighbors.Add(Clone(n));
        }

        return _adjacencyTable[node];
    }

    public Node CloneGraph(Node node) {
        if (node == null) {
            return null;
        }

        return Clone(node);
    }
}