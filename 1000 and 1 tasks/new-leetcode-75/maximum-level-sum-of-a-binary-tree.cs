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
    public int MaxLevelSum(TreeNode root) {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        long max = root.val;
        var maxLevel = 1;
        var level = 0;

        while (queue.Any()) {
            var size = queue.Count();
            long sum = 0;
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                }
                sum += cur.val;
            }
            level++;
            if (sum > max) {
                max = sum;
                maxLevel = level;
            }
        }

        return maxLevel;
    }
}