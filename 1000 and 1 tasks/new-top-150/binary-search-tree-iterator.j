import java.util.ArrayDeque;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class BSTIterator {
    
    private TreeNode _current;
    private ArrayDeque<TreeNode> _stack;

    public BSTIterator(TreeNode root) {
        _current = root;
        _stack = new ArrayDeque<TreeNode>();
    }

    public int next() {
        while (_current != null) {
            _stack.push(_current);
            _current = _current.left;
        }
        var result = _stack.pop();
        _current = result.right;
        return result.val;
    }

    public boolean hasNext() {
        return _current != null || !_stack.isEmpty();
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.next();
 * boolean param_2 = obj.hasNext();
 */