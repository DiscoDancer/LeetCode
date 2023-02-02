/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    // level traversal
    public Node Connect(Node root) {
        if (root == null) {
            return null;
        }

        var queue = new Queue<Node>();
        queue.Enqueue(root);
        var expectedChildren = 1;

        while (queue.Any()) {
            Node prev = null;
            for (int i = 0; i < expectedChildren; i++) {
                var cur = queue.Dequeue();
                if (prev != null) {
                    prev.next = cur;
                }
                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                }
                prev = cur;
            }

            expectedChildren = expectedChildren << 1;
        }

        return root;
    }
}