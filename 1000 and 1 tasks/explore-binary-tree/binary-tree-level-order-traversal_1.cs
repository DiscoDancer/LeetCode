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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var queue = new Queue<TreeNode>();
        if (root != null) {
            queue.Enqueue(root);
        }

        var result = new List<IList<int>>();
        while (queue.Any()) {
            var countChildren = queue.Count();
            var level = new List<int>();
            for (int i = 0; i < countChildren; i++) {
                var cur = queue.Dequeue();
                level.Add(cur.val);

                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                }
            }

            if (level.Any()) {
                result.Add(level);
            }
        }

        return result;
    }
}