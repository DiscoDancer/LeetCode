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
    
    private List<int> _list = new List<int>();
    
    public void F(Node root) {
        _list.Add(root.val);
        
        foreach (var c in root.children) {
            F(c);
        }
    }
    
    public IList<int> Preorder(Node root) {
        if (root == null) {
            return new List<int>();
        }
        
        F(root);
        
        return _list;
    }
}