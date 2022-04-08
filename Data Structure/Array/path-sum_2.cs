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
    public bool HasPathSum(TreeNode root, int targetSum) {
        if (root == null) {
            return false;
        }
        
        var newsum = targetSum - root.val;
        if (root.left == null && root.right == null) {
            return newsum == 0;
        }
        
        return HasPathSum(root.left, newsum) || HasPathSum(root.right, newsum);
    }
}