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
        if (root == null) {
            return 0;
        }

        var max = 1;
        foreach (var c in root.children) {
            max = Math.Max(MaxDepth(c) + 1, max);
        }

        return max;
    }
}