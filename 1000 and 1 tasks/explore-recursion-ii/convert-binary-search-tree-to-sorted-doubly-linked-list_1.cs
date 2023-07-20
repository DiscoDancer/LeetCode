/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;

    public Node() {}

    public Node(int _val) {
        val = _val;
        left = null;
        right = null;
    }

    public Node(int _val,Node _left,Node _right) {
        val = _val;
        left = _left;
        right = _right;
    }
}
*/

public class Solution {
    public Node TreeToDoublyList(Node root) {
        if (root == null) {
            return root;
        }

        var fakeHead = new Node();
        var fakeTail = fakeHead;

        var left = root;
        var stack = new Stack<Node>();
        var prev = (Node)null;
        while (left != null || stack.Any()) {
            while (left != null) {
                stack.Push(left);
                left = left.left;
            }
            var cur = stack.Pop();
            left = cur.right;

            cur.left = prev;
            // isolated
            cur.right = null;

            fakeTail.right = cur;
            fakeTail = fakeTail.right;

            prev = cur;
        }

        var head = fakeHead.right;
        var tail = fakeTail;

        head.left = tail;
        tail.right = head;

        return head;
    }
}