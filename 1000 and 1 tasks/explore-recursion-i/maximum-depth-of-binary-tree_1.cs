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
    public int MaxDepth(TreeNode root) {
        var max = 0;

        var queue = new Queue<TreeNode>();
        if (root != null) {
            queue.Enqueue(root);
        }

        while (queue.Any()) {
            var size = queue.Count();
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                if (cur.left != null) {
                    queue.Enqueue(cur.left );
                }
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                }
            }
            max++;
        }

        return max;
    }
}