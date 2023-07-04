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

    public IList<int> Preorder(Node root) {
        var stack = new Stack<Node>();
        if (root != null) {
            stack.Push(root);
        }

        while (stack.Any()) {
            var cur = stack.Pop();
            _result.Add(cur.val);
            for (int i = cur.children.Count() - 1; i >= 0; i-- ) {
                stack.Push(cur.children[i]);
            }
        }
       
        return _result;
    }
}