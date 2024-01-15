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


// editorial

public class Solution {
    private int diameter = 0;

    protected int maxDepth(Node node, int currDepth)  {
        if (!node.children.Any())
            return currDepth;

        // select the top two largest depths
        int maxDepth1 = currDepth, maxDepth2 = 0;
        foreach (var child in node.children) {
            int depth = maxDepth(child, currDepth + 1);
            if (depth > maxDepth1) {
                maxDepth2 = maxDepth1;
                maxDepth1 = depth;
            } else if (depth > maxDepth2) {
                maxDepth2 = depth;
            }
            // calculate the distance between the two farthest leaves nodes.
            int distance = maxDepth1 + maxDepth2 - 2 * currDepth;
            this.diameter = Math.Max(this.diameter, distance);
        }

        return maxDepth1;
    }

    public int Diameter(Node root) {
        this.diameter = 0;
        maxDepth(root, 0);
        return diameter;
    }
}