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
        var result = new List<IList<int>>();

        var queue = new Queue<TreeNode>();
        if (root != null) {
            queue.Enqueue(root);
        }

        while (queue.Any()) {
            var size = queue.Count();
            var arr = new int[size];

            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                arr[i] = cur.val;

                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                }
            }

            result.Add(arr);
        }

        return result;
    }
}