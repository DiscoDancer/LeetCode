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
    public bool IsValidBST(TreeNode root) {
        var stack = new Stack<TreeNode>();
        var left = root;
        var prev = (int?) null;

        // inorder
        while (left != null || stack.Any()){
            while (left != null)
            {
                stack.Push(left);
                left = left.left;
            }
            var top = stack.Pop();
            if (prev != null && prev.Value >= top.val) {
                return false;
            }
            prev = top.val;
            left = top.right;
        }
        
        return true;
    }
}