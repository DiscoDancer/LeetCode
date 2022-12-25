/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {

    private int _maxDepth = 0;

    private void MaxDepthInner(TreeNode root, int depth) {
        _maxDepth = Math.Max(_maxDepth, depth);

        if (root.left != null) {
            MaxDepthInner(root.left, depth + 1);
        }

        if (root.right != null) {
            MaxDepthInner(root.right, depth + 1);
        }
    }

    public int MaxDepth(TreeNode root) {
        if (root != null) {
            MaxDepthInner(root, 1);
        }

        return _maxDepth;
    }
}