import java.util.Stack;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * int val;
 * TreeNode left;
 * TreeNode right;
 * TreeNode() {}
 * TreeNode(int val) { this.val = val; }
 * TreeNode(int val, TreeNode left, TreeNode right) {
 * this.val = val;
 * this.left = left;
 * this.right = right;
 * }
 * }
 */
class Solution {

    public int kthSmallest(TreeNode root, int k) {
        // do inorder
        var stack = new Stack<TreeNode>();
        var current = root;
        var processed = 0;
        while (!stack.isEmpty() || current != null) {
            while (current != null) {
                stack.push(current);
                current = current.left;
            }
            current = stack.pop();
            if (++processed == k) {
                return current.val;
            }
            current = current.right;
        }
        throw new RuntimeException("k is out of bounds");
    }
}