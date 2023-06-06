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
    public bool AreSame(TreeNode a, TreeNode b) {
        return a?.val == b?.val;
    }

    public bool IsSymmetric(TreeNode a, TreeNode b) {
        if (a == null && b == null) {
            return true;
        }
        if (a == null || b == null) {
            return false;
        }
        return a.val == b.val && IsSymmetric(a.left, b.right) && IsSymmetric(a.right, b.left);
    }

    public bool IsSymmetric(TreeNode root) {
        return IsSymmetric(root, root);
    }
}