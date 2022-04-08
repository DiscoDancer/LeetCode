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
    public bool DFS(TreeNode root, int? L, int? R) {
       if (root == null) {
           return true;
       }
        
        if (L.HasValue && root.val <= L.Value || R.HasValue && root.val >= R.Value) {
            return false;
        }
        
        return DFS(root.left, L, root.val) && DFS(root.right, root.val, R);
    }
    
    public bool IsValidBST(TreeNode root) {
        if (root == null) {
            return false;
        }
        
        return DFS(root, null, null);
    }
}