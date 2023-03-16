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

        queueP.Enqueue(p);
        queueQ.Enqueue(q);

        while (queueP.Any() && queueQ.Any()) {
            var curP = queueP.Dequeue();
            var curQ = queueQ.Dequeue();

            if (curP != null && curQ == null || curP == null && curQ != null) {
                return false;
            }
            if (curP == null && curQ == null) {
                continue;
            }
            if (curP.val != curQ.val) {
                return false;
            }

            queueP.Enqueue(curP.left);
            queueQ.Enqueue(curQ.left);

            queueP.Enqueue(curP.right);
            queueQ.Enqueue(curQ.right);
        }
        
        return true;
    }
}