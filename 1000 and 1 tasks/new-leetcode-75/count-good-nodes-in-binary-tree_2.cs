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
    public int GoodNodes(TreeNode root) {
        var queue = new Queue<(TreeNode node, int max)>();
        queue.Enqueue((root, int.MinValue));

        var count = 0;

        while (queue.Any()) {
            var (node, max) = queue.Dequeue();

            if (node.left != null) {
                queue.Enqueue((node.left, Math.Max(max, node.val)));
            }
            if (node.right != null) {
                queue.Enqueue((node.right, Math.Max(max, node.val)));
            }

            count += node.val >= max ? 1 : 0;
        }

        return count;
    }
}