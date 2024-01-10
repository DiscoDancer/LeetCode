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
    public IList<int> ClosestKValues(TreeNode root, double target, int k) {
        var result = new List<int>();

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var pq = new PriorityQueue<int, double>();

        while (queue.Any()) {
            var cur = queue.Dequeue();
            pq.Enqueue(cur.val, -Math.Abs((double)cur.val - target));

            if (cur.left != null) {
                queue.Enqueue(cur.left);
            }
            if (cur.right != null) {
                queue.Enqueue(cur.right);
            }

            if (pq.Count > k) {
                pq.Dequeue();
            }
        }

        while (pq.Count > 0) {
            result.Add(pq.Dequeue());
        }

        return result;
    }
}