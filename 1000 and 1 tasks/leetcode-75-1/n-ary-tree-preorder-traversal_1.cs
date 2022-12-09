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

    private List<int> _res = new();

    public void Traverse(Node root) {
        if (root == null) {
            return;
        }
        
        _res.Add(root.val);

        foreach (var c in root.children) {
            Traverse(c);
        }
    }

    public IList<int> Preorder(Node root) {

        Traverse(root);
        return _res;

        var result = new List<int>();
        var stack = new Stack<Node>();
        stack.Push(root);

        while (stack.Any()) {
            var current = stack.Pop();
            if (current == null) {
                continue;
            }
            
            result.Add(current.val);

            // своих детей нужно добавлять в начало очереди
            var cc = current.children.ToArray();
            for (int i = cc.Length - 1; i >= 0; i--) {
                stack.Push(cc[i]);
            }
        }

        return result;
    }
}