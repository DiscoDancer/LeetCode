/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    // BFS
    // DFS
    public int MaxDepth(Node root) {
        var queue = new Queue<Node>();
        if (root != null) {
            queue.Enqueue(root);
        }

        var result = 0;

        while (queue.Any()) {
            var size = queue.Count();
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                foreach (var c in cur.children) {
                     queue.Enqueue(c);
                }
            }
            result++;
        }

        return result;
    }
}