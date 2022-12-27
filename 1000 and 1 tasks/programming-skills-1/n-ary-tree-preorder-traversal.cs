/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {

    private List<int> _res = new List<int>();

    private void PreorderInner(Node root) {
        _res.Add(root.val);

        if (root.children == null) {
            return;
        }

        foreach (var c in root.children) {
            PreorderInner(c);
        }
    }

    public IList<int> Preorder(Node root) {
        if (root == null) {
            return new List<int>();
        }

        PreorderInner(root);

        return _res;
    }
}