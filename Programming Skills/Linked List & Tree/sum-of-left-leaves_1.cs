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
    public int F(TreeNode root, bool isLeft) {
        if (root == null) {
            return 0;
        }
        
        if (root.left == null && root.right == null) {
            return isLeft ? root.val : 0;
        }
        
        return F(root.left, true) + F(root.right, false);
    }
    
    public int SumOfLeftLeaves(TreeNode root) {
        if (root == null) {
            return 0;
        }
        
        return F(root, false);
        
    }
}