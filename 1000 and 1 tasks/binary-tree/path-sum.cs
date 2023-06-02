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
        var queue = new Queue<(TreeNode, int)>();
        if (root != null) {
            queue.Enqueue((root, root.val));
        }

        while (queue.Any()) {
            var (cur, sum) = queue.Dequeue();
            if (sum == targetSum && cur.left == null && cur.right == null) {
                return true;
            }

            if (cur.left != null) {
                queue.Enqueue((cur.left, cur.left.val + sum));
            }
            if (cur.right != null) {
                queue.Enqueue((cur.right, cur.right.val + sum));
            }
        }

        return false;
    } 
}