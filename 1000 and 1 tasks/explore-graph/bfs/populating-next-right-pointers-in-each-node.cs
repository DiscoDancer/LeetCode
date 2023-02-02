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
    public Node Connect(Node root) {
        if (root == null) {
            return null;
        }

        var queue = new Queue<(Node node, int level)>();
        queue.Enqueue((root, 1));

        (Node node, int level) prev = (null, 0);

        while (queue.Any()) {
            var (node, level) = queue.Dequeue();

            if (prev.level == level) {
                prev.node.next = node;
            }


            if (node.left != null) {
                queue.Enqueue((node.left, level + 1));
                queue.Enqueue((node.right, level + 1));
            }

            prev = (node, level);
        }

        return root;
    }
}