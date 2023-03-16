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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        var queueP = new Queue<TreeNode>();
        var queueQ = new Queue<TreeNode>();

        if (p != null) {
            queueP.Enqueue(p);
        }
        if (q != null) {
            queueQ.Enqueue(q);
        }

        while (queueP.Any() && queueQ.Any()) {
            var curP = queueP.Dequeue();
            var curQ = queueQ.Dequeue();

            if (curP.val != curQ.val) {
                return false;
            }

            if (curP.left != null && curQ.left != null) {
                queueP.Enqueue(curP.left);
                queueQ.Enqueue(curQ.left);
            }
            if (curP.left != null && curQ.left == null || curP.left == null && curQ.left != null) {
                return false;
            }

            if (curP.right != null && curQ.right != null) {
                queueP.Enqueue(curP.right);
                queueQ.Enqueue(curQ.right);
            }
            if (curP.right != null && curQ.right == null || curP.right == null && curQ.right != null) {
                return false;
            }
        }

        if (queueP.Any() || queueQ.Any()) {
            return false;
        }

        return true;
    }
}