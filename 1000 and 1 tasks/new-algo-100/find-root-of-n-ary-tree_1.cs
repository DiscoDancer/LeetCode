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
    public Node FindRoot(List<Node> tree) {
        var valueSum = 0;

        foreach (var node in tree) {
            // the value is added as a parent node
            valueSum += node.val;
            foreach (var child in node.children)
                // the value is deducted as a child node.
                valueSum -= child.val;
        }

        Node root = null;
        // the value of the root node is `valueSum`
        foreach (var node in tree) {
            if (node.val == valueSum) {
                root = node;
                break;
            }
        }
        return root;
    }
}