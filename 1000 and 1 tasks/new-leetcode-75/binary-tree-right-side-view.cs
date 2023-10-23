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
    // идем по уровняем и берем последний
    public IList<int> RightSideView(TreeNode root) {
        var result = new List<int>();
        var queue = new Queue<TreeNode>();
        if (root != null) {
            queue.Enqueue(root);
        }

        while (queue.Any()) {
            var size = queue.Count();
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                }
                if (i == size - 1) {
                    result.Add(cur.val);
                }
            }
        }

        return result;
    }
}