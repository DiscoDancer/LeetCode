class Solution {

    // квадрат

    private Node _head = null;
    private Node _tail = null;

    private void Inorder(Node root, int height) {
        if (root.left != null) {
            Inorder(root.left, height + 1);
        }
        if (_head == null) {
            _head = root;
        } else {
            _tail.next = root;
        }
        _tail = root;
        root.val += height*1000 * (root.val < 0 ? -1 : 1);
        if (root.right != null) {
            Inorder(root.right, height + 1);
        }
    }

    public Node connect(Node root) {
        if (root == null) {
            return null;
        }

        Inorder(root, 0);

        var p = _head;
        while (p != null) {
            var pTrueVal = p.val % 1000;
            var pHeight = (Math.abs(p.val) - Math.abs(pTrueVal)) / 1000 % 1000;

            var pNext = p.next;
            p.next = null;

            var q = pNext;
            while (q != null) {
                var qTrueVal = q.val % 1000;
                var qHeight = (Math.abs(q.val) - Math.abs(qTrueVal)) / 1000 % 1000;
                if (pHeight == qHeight) {
                    p.next = q;
                    break;
                }
                q = q.next;
            }

            p.val = pTrueVal;

            System.out.printf("val: %d, true val: %d, height: %d%n", p.val, pTrueVal, pHeight);

            p = pNext;
        }

        return root;
    }
}