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

// Периметр = высота L + высота R, надо найти максимальный
// Похоже на balanced-binary-tree
public class Solution {
    private int _max = 0;

    private int Height(TreeNode root) {
        if (root == null) {
            return 0;
        }

        var left = Height(root.left);
        var right = Height(root.right);

        _max = Math.Max(left + right, _max);

        return 1 + Math.Max(left, right);
    }

    public int DiameterOfBinaryTree(TreeNode root) {
        Height(root);
        return _max;
    }
}