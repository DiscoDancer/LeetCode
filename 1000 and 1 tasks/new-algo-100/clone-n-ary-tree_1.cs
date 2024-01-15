/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;
    
    public Node() {
        val = 0;
        children = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        children = new List<Node>();
    }
    
    public Node(int _val, List<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/


public class Solution {
    public Node CloneTree(Node root) {
        Node result = null;

        var queue = new Queue<(Node old, Node nova)>();
        if (root != null) {
            result = new Node(root.val);
            queue.Enqueue((root, result));
        }

        while (queue.Any()) {
            var (cur, converted) = queue.Dequeue();

            foreach (var c in cur.children) {
                var convertedC = new Node(c.val);
                converted.children.Add(convertedC);
                queue.Enqueue((c, convertedC));
            }
        }

        return result;
    }
}