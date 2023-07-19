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

// немного списал с editorial, но потому что они сами разобрали в статье
public class Solution {
    public bool IsSameNode(TreeNode p, TreeNode q) {
        if (p == null && q == null) {
            return true;
        }
        if (p == null || q == null) {
            return false;
        }

        return p.val == q.val;
    }

    public bool IsSameTree(TreeNode p, TreeNode q) {
        if (!IsSameNode(p,q)) {
            return false;
        }

        var q1 = new Queue<TreeNode>();
        var q2 = new Queue<TreeNode>();

        if (p != null) {
            q1.Enqueue(p);
            q2.Enqueue(q);
        }

        while (q1.Any() && q2.Any()) {
            var pp = q1.Dequeue();
            var qq = q2.Dequeue();

            if (!IsSameNode(pp.left, qq.left) || !IsSameNode(pp.right, qq.right)) {
                return false;
            }

            if (pp.left != null) {
                q1.Enqueue(pp.left);
                q2.Enqueue(qq.left);
            }

            if (pp.right != null) {
                q1.Enqueue(pp.right);
                q2.Enqueue(qq.right);
            }
        }

        return !q1.Any() && !q2.Any();
    }
}