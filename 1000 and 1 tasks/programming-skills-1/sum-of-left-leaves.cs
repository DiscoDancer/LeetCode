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

    private int _sum = 0;

    private void SumOfLeftLeavesInner(TreeNode root) {
        if (root.left != null) {
            if (root.left.left == null && root.left.right == null) {
                _sum += root.left.val;
            }
            SumOfLeftLeaves(root.left);
        }
        if (root.right != null) {
            SumOfLeftLeaves(root.right);
        }
    }

    public int SumOfLeftLeaves(TreeNode root) {
        if (root == null) {
            return 0;
        }

        SumOfLeftLeavesInner(root);

        return _sum;
    }
}