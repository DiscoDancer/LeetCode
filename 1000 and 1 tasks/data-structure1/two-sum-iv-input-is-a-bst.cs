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
    // квадратик для каждого искать по разу (n * logn)
    // можно inorder и binary search (n * logn; доп память); 
    // можно просто обойти в хеш таблицу тогда (n, но доп память; факт BST ничего не дает)
    public bool FindTarget(TreeNode root, int k) {
        if (root == null || root.left == null && root.right == null) {
            return false;
        }

        var hs = new HashSet<int>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Any()) {
            var cur = queue.Dequeue();

            var remaining = k - cur.val;

            if (hs.Contains(remaining)) {
                return true;
            }
            hs.Add(cur.val);

            if (cur.left != null) {
                queue.Enqueue(cur.left);
            }
            if (cur.right != null) {
                queue.Enqueue(cur.right);
            }
        }

        return false;
    }
}