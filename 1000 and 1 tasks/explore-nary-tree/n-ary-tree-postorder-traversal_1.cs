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
    private List<int> _result = new ();

    public IList<int> Postorder(Node root) {
        var stack = new Stack<Node>();
        if (root != null) {
            stack.Push(root);
        }

        // я интуитивно додумался, что можно сделать наборот с preorder
        while (stack.Any()) {
            var cur = stack.Pop();
            _result.Add(cur.val);
            foreach (var c in cur.children) {
                stack.Push(c);
            }
        }

        _result.Reverse();

        return _result;
    }
}