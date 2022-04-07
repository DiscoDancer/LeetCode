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
        
        var stack = new Stack<(TreeNode node, int acc)>();
        stack.Push((root, 0));
        
        while (stack.Any()) {
            var cur = stack.Pop();
            if (cur.node.left == null && cur.node.right == null) {
                if (cur.node.val + cur.acc == targetSum) {
                    return true;
                }
            }
            
            if (cur.node.left != null) {
                stack.Push((cur.node.left, cur.acc + cur.node.val));
            }
            if (cur.node.right != null) {
                stack.Push((cur.node.right, cur.acc + cur.node.val));
            }
        }
        return false;  
    }
}