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
        if (root == null) {
            return false;
        }

        var stack = new Stack<TreeNode>();
        stack.Push(root);
        int? prev = null;

        while (stack.Any()) {
            var top = stack.Peek();
            if (top.left != null) {
                while (top.left != null) {
                    var tmp = top;
                    stack.Push(top.left);
                    tmp.left = null;
                }
                continue;
            }

            var cur = stack.Pop();
            if (prev != null && prev.Value >= cur.val) {
                return false;
            }
            prev = cur.val;

            if (cur.right != null) {
                stack.Push(cur.right);
            }
        }

        return true;
    }
}