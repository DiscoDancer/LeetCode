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
    private int F(TreeNode root) {
        if (root == null) {
            return 0;
        }

        return Math.Max(F(root.left), F(root.right)) + 1;
    }

    public int MaxDepth(TreeNode root) {
        return F(root);
    }
}