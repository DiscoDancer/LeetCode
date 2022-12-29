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

    private void PreOrder(TreeNode root, int h) {
        _max = Math.Max(_max, h);
        if (root.left != null) {
            PreOrder(root.left, h + 1);
        }
        if (root.right != null) {
            PreOrder(root.right, h + 1);
        }
    }

    private int _max = 1;

    public int MaxDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }

        PreOrder(root, 1);

        return _max;
        
    }
}