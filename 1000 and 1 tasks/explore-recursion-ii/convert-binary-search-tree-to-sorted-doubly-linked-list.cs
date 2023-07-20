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

    // inorder дает sorted список
    // если мы захватим prev можно мутить со связями
    // мб самый левый еще надо запомнить, чтобы замкнуться

    private void Inorder(Node root) {
        if (root == null) {
            return;
        }
        Inorder(root.left);
        // proccess root
        Inorder(root.right);
    }

    private void IterativeInorder(Node root) {
        var left = root;
        var stack = new Stack<Node>();
        while (left != null || stack.Any()) {
            while (left != null) {
                stack.Push(left);
                left = left.left;
            }
            var cur = stack.Pop();
            // proccess cur
            left = cur.right;
        }
    }

    // right = next
    // left = prev

    public Node TreeToDoublyList(Node root) {
        if (root == null) {
            return root;
        }

        var fakeHead = new Node();
        var fakeTail = fakeHead;

        var left = root;
        var stack = new Stack<Node>();
        while (left != null || stack.Any()) {
            while (left != null) {
                stack.Push(left);
                left = left.left;
            }
            var cur = stack.Pop();
            left = cur.right;

            // isolated

            cur.left = null;
            cur.right = null;
            fakeTail.right = cur;
            fakeTail = fakeTail.right;
        }

        var head = fakeHead.right;
        var tail = fakeTail;

        // todo проставить prev
        var prev = (Node)null;
        var p = head;

        while (p != null) {
            p.left = prev;
            prev = p;
            p = p.right;
        }

        head.left = tail;
        tail.right = head;

        return head;
    }
}