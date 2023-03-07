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
    public TreeNode InvertTree(TreeNode root) {
        if (root == null) {
            return root;
        }

        var stack = new Stack<TreeNode>();
        stack.Push(root);
        
        while (stack.Any()) {
            var cur = stack.Pop();

            var tmp = cur.left;
            cur.left = cur.right;
            cur.right = tmp;

            if (cur.left != null) {
                stack.Push(cur.left);
            }

            if (cur.right != null) {
                stack.Push(cur.right);
            }
        }
        return root;
    }
}