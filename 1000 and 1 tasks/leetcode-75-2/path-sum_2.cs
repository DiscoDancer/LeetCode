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
        var queue = new Queue<(TreeNode node, int sum)>();

        if (root != null) {
            queue.Enqueue((root, 0));
        }

        while (queue.Any()) {
            var (node, sum) = queue.Dequeue();

            var newSum = sum + node.val;
            if (newSum == targetSum && node.left == null && node.right == null) {
                return true;
            }

            if (node.right != null) {
                queue.Enqueue((node.right, newSum));
            }
            if (node.left != null) {
                queue.Enqueue((node.left, newSum));
            }
        }

        return false;

    }
}