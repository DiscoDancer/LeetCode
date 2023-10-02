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
        var q = new Queue<(TreeNode node, int h)>();
        var max = 0;

        if (root != null) {
            q.Enqueue((root, 1));
        }

        while (q.Any()) {
            var cur = q.Dequeue();
            max = Math.Max(max, cur.h);
            if (cur.node.left != null) {
                q.Enqueue((cur.node.left, cur.h + 1));
            }
            if (cur.node.right != null) {
                q.Enqueue((cur.node.right, cur.h + 1));
            }
        }


        return max;
    }
}