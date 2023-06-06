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
    // https://leetcode.com/problems/symmetric-tree/editorial/
    public bool IsSymmetric(TreeNode root) {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(root);

        while (queue.Any()) {
            var t1 = queue.Dequeue();
            var t2 = queue.Dequeue();
            if (t1 == null && t2 == null) {
                continue;
            }
            if (t1 == null || t2 == null || t1.val != t2.val) {
                return false;
            }
            queue.Enqueue(t1.left);
            queue.Enqueue(t2.right);
            queue.Enqueue(t1.right);
            queue.Enqueue(t2.left);
        }

        return true;
    }
}