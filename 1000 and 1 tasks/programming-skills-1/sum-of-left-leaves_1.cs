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
    public int SumOfLeftLeaves(TreeNode root) {
        if (root == null) {
            return 0;
        }

        var stack = new Stack<TreeNode>();
        stack.Push(root);
        var sum = 0;

        while (stack.Any()) {
            var cur = stack.Pop();

            if (cur.left != null) {
                if (cur.left.left == null && cur.left.right == null) {
                    sum += cur.left.val;
                }
                stack.Push(cur.left);
            }
            if (cur.right != null) {
                stack.Push(cur.right);
            }
        }

        return sum;
    }
}