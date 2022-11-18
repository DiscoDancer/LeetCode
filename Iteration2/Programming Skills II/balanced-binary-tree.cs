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
    
    private bool _result = true;
    
    public int CheckHeight(TreeNode node, int inc) {        
        var l = node.left != null ? CheckHeight(node.left, inc + 1) : 0;
        var r = node.right != null ? CheckHeight(node.right, inc + 1) : 0;
        
        if (Math.Abs(l - r) > 1) {
            _result = false;
        }
        
        return Math.Max(l, r) + 1;
    }
    
    public bool IsBalanced(TreeNode root) {
        if (root == null || root.left == null && root.right == null) {
            return true;
        }
        
        CheckHeight(root, 0);
        
        return _result;
    }
}