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
    
    public int _max = 0;
    
    public void F(TreeNode root, int level) {
        _max = Math.Max(level, _max);
        
        if (root != null) {
            if (root.left != null) {
                F(root.left, level + 1);
            }
            if (root.right != null) {
                F(root.right, level + 1);
            }
        }
    }
    
    public int MaxDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }
        
        F(root, 1);
        
        return _max;
    }
}