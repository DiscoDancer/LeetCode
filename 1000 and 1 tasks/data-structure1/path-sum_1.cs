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
            var (node, acc) = stack.Pop();
            var newAcc = node.val + acc;

            if (node.left == null && node.right == null && newAcc == targetSum) {
                return true;
            }

            if (node.left != null) {
                stack.Push((node.left , newAcc));
            }

            if (node.right != null) {
                stack.Push((node.right , newAcc));
            }
        }

        return false;
    }
}