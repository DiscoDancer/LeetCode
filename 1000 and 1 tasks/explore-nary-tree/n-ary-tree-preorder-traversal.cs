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
    private List<int> _result = new ();

    private void F(Node root) {
        if (root == null) {
            return;
        }
        _result.Add(root.val);
        foreach (var c in root.children) {
            F(c);
        }
    }

    public IList<int> Preorder(Node root) {
        F(root);
        return _result;
    }
}