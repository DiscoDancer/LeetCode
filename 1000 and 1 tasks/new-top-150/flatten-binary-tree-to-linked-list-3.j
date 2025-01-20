import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Stack;

class Solution {

    private class PreorderIterator implements Iterator<TreeNode> {
        private Stack<TreeNode> stack;
        private TreeNode current;

        public PreorderIterator(TreeNode root) {
            this.current = root;
            this.stack = new Stack<>();
        }

        @Override
        public boolean hasNext() {
            return this.current != null || !this.stack.isEmpty();
        }

        @Override
        public TreeNode next() {
            if (current == null) {
                current = stack.pop();
            }
            var result = current;
            if (current.right != null) {
                stack.push(current.right);
            }
            current = current.left;
            return result;
        }
    }

    private class InorderIterator implements Iterator<TreeNode> {
        private Stack<TreeNode> stack;
        private TreeNode current;

        public InorderIterator(TreeNode root) {
            this.current = root;
            this.stack = new Stack<>();
        }

        @Override
        public boolean hasNext() {
            return this.current != null || !this.stack.isEmpty();
        }

        @Override
        public TreeNode next() {
            if (this.current != null) {
                while (this.current.left != null) {
                    stack.push(this.current);
                    this.current = this.current.left;
                }
                var result = this.current;
                this.current = current.right;
                return result;
            }
            else {
                this.current = stack.pop();
                var result = this.current;
                this.current = this.current.right;
                return result;
            }
        }
    }

    private final static int PLUS = 2;
    private final static int MINUS = 3;

    private static void setExtraValue(TreeNode node, int value) {
        node.val += Math.abs(value) * 1000 * (node.val < 0 ? -1 : 1);
        node.val += (value <= 0 ? MINUS : PLUS) * 1_000_000 * (node.val < 0 ? -1 : 1);
    }

    private static int getExtraValue(TreeNode node) {
        var preorderValueAbs = (Math.abs(node.val) / 1000) % 1000;
        var preorderValueSign = (Math.abs(node.val) / 1000_000) == PLUS ? 1 : -1;

        return preorderValueAbs * preorderValueSign;
    }

    public void flatten(TreeNode root) {

        if (root == null) {
            return;
        }



        var preorderIterator = new PreorderIterator(root);
        var inorderIterator = new InorderIterator(root);

        while (preorderIterator.hasNext()) {
            var preorderNode = preorderIterator.next();
            var inorderNode = inorderIterator.next();

            var preorderTrueValue = preorderNode.val % 1000;
            setExtraValue(inorderNode, preorderTrueValue);
        }

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