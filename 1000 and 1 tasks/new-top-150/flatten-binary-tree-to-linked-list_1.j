import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Stack;

// с моей точки зрения верно, но не засчитывает

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


    public List<Integer> inorderTraversal(TreeNode root) {
        var result = new ArrayList<Integer>();
        var iterator = new PreorderIterator(root);
        while (iterator.hasNext()) {
            result.add(iterator.next().val);
        }
        for (var i : result) {
            System.out.println(i);
        }
        return result;
    }

    public void flatten(TreeNode root) {

        if (root == null) {
            return;
        }

        final int PLUS = 2;
        final int MINUS = 3;

        var preorderIterator = new PreorderIterator(root);
        var inorderIterator = new InorderIterator(root);

        while (preorderIterator.hasNext()) {
            var preorderNode = preorderIterator.next();
            var inorderNode = inorderIterator.next();

            var preorderTrueValue = preorderNode.val % 1000;

            inorderNode.val += Math.abs(preorderTrueValue) * 1000 * (inorderNode.val < 0 ? -1 : 1);
            inorderNode.val += (preorderTrueValue <= 0 ? MINUS : PLUS) * 1_000_000 * (inorderNode.val < 0 ? -1 : 1);

            System.out.println(inorderNode.val);
        }

        inorderIterator = new InorderIterator(root);
        var fakeRoot = new TreeNode(0);
        var prev = fakeRoot;
        while (inorderIterator.hasNext()) {
            var node = inorderIterator.next();

            var preorderValueAbs = (Math.abs(node.val) / 1000) % 1000;
            var preorderValueSign = (Math.abs(node.val) / 1000_000) == PLUS ? 1 : -1;
            var preorderValue = preorderValueAbs * preorderValueSign;

            System.out.println(preorderValue);

            node.val = preorderValue;

            prev.right = node;
            prev.left = null;
            prev = node;
        }

        root = fakeRoot.right;
    }
}