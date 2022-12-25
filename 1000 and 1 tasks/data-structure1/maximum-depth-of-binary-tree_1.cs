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
        if (root == null) {
            return 0;
        }

        var expectingChildren = 1;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var levels = 0;
        while (queue.Any()) {
            var newExpectingChildren = 0;
            levels++;
            for (int i = 0; i < expectingChildren; i++) {
                var cur = queue.Dequeue();

                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                    newExpectingChildren++;
                }
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                    newExpectingChildren++;
                }
            }
            expectingChildren = newExpectingChildren;
        }

        return levels;
    }
}