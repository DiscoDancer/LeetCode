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
    public IList<int> Preorder(Node root) {
        if (root == null) {
            return new List<int>();
        }

        var stack = new Stack<Node>();
        stack.Push(root);

        var res = new List<int>();

        while (stack.Any()) {
            var cur = stack.Pop();
            res.Add(cur.val);

            if (cur.children == null) {
                continue;
            }

            var arr = cur.children.ToArray();
            for (int i = arr.Length - 1; i >= 0; i--) {
                stack.Push(arr[i]);
            }
        }
        return res;
    }
}