import java.util.ArrayDeque;
import java.util.Iterator;

class Solution {

    private static class PreorderIterator implements Iterator<TreeNode> {
        private final ArrayDeque<TreeNode> stack;
        private TreeNode current;

        public PreorderIterator(TreeNode root) {
            this.current = root;
            this.stack = new ArrayDeque<>();
        }

        @Override
        public boolean hasNext() {
            return this.current != null || !this.stack.isEmpty();
        }

        @Override
        public TreeNode next() {
            if (this.current == null) {
                this.current = this.stack.pop();
            }
            var result = current;
            if (this.current.right != null) {
                this.stack.push(this.current.right);
            }
            this.current = this.current.left;
            return result;
        }
    }

    private static class InorderIterator implements Iterator<TreeNode> {
        private final ArrayDeque<TreeNode> stack;
        private TreeNode current;

        public InorderIterator(TreeNode root) {
            this.current = root;
            this.stack = new ArrayDeque<>();
        }

        @Override
        public boolean hasNext() {
            return this.current != null || !this.stack.isEmpty();
        }

        @Override
        public TreeNode next() {
            while (this.current != null) {
                this.stack.push(this.current);
                this.current = this.current.left;
            }
            this.current = this.stack.pop();
            var result = this.current;
            this.current = this.current.right;
            return result;
        }
    }

    private final static int PLUS = 2;
    private final static int MINUS = 3;

    /**
     * Encodes an extra value into node.val by:
     *  - Storing sign (+/-) in the 1,000,000s place
     *  - Storing magnitude in the 1,000s place
     *  - Preserving the original sign of node.val
     */
    private static void setExtraValue(TreeNode node, int value) {
        var nodeSign = (node.val < 0 ? -1 : 1);
        node.val += Math.abs(value) * 1_000 * nodeSign;
        node.val += (value <= 0 ? MINUS : PLUS) * 1_000_000 * nodeSign;
    }

    /**
     * Decodes the extra value from node.val,
     * extracting sign from the 1,000,000s place,
     * magnitude from the 1,000s place.
     */
    private static int getExtraValue(TreeNode node) {
        var absVal    = Math.abs(node.val);
        var valueAbs  = (absVal / 1_000) % 1_000;
        var signPart  = (absVal / 1_000_000);
        var valueSign = (signPart == PLUS) ? 1 : -1;

        return valueAbs * valueSign;
    }

    public void flatten(TreeNode root) {
        if (root == null) {
            return;
        }

        var preorderIterator = new PreorderIterator(root);
        var inorderIterator = new InorderIterator(root);

        // inorder nodes know their preorder equivalent
        while (preorderIterator.hasNext()) {
            var preorderNode = preorderIterator.next();
            var inorderNode = inorderIterator.next();

            var preorderTrueValue = preorderNode.val % 1000;
            setExtraValue(inorderNode, preorderTrueValue);
        }

        // flatten the tree into a list and replace the values with preorder equivalent
        inorderIterator = new InorderIterator(root);
        TreeNode head = null;
        TreeNode tail = null;
        while (inorderIterator.hasNext()) {
            var node = inorderIterator.next();
            if (head == null) {
                head = node;
            }

            node.val = getExtraValue(node);

            if (tail != null) {
                tail.right = node;
            }
            tail = node;
            tail.left = null;
        }

        // make root the first node
        var cur = head;
        while (cur != root) {
            var next = cur.right;
            cur.right = null;
            tail.right = cur;
            tail = tail.right;
            cur = next;
        }

        // set values in expected order
        var curRead = head;
        var curWrite = root;
        do {
           var valueToWrite = curRead.val % 1000;
           setExtraValue(curWrite, valueToWrite);

           curRead = curRead.right;
           if (curRead == null) {
               curRead = root;
           }
           curWrite = curWrite.right;
        } while (curRead != head);

        var p = root;
        while (p != null) {
            p.val = getExtraValue(p);
            p = p.right;
        }
    }
}