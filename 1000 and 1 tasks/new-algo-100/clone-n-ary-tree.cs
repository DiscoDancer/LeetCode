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
        var conversionTable = new Dictionary<Node, Node>();

        var queue = new Queue<Node>();
        if (root != null) {
            queue.Enqueue(root);
            conversionTable[root] = new Node(root.val);
        }

        while (queue.Any()) {
            var cur = queue.Dequeue();
            var converted = conversionTable[cur];

            foreach (var c in cur.children) {
                conversionTable[c] = new Node(c.val);
                converted.children.Add(conversionTable[c]);
                queue.Enqueue(c);
            }
        }

        return root == null ? root : conversionTable[root];
    }
}