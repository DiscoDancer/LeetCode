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

    public bool IsValidBST(TreeNode r) {
        if (r == null) {
            return false;
        }
        
        int? prev = null;
        var stack = new Stack<TreeNode>();
        
        var root = r;
        
        while (root != null || stack.Any()) {
            while (root != null) {
                stack.Push(root);
                root = root.left;
            }
            
            root = stack.Pop();
            
            if (prev.HasValue && prev >= root.val) {
                return false;
            }
            
            prev = root.val;
            root = root.right;
        }
        return true;
    }
}