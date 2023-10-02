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
    public TreeNode InvertTree(TreeNode root) {
        if (root == null) {
            return root;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Any()) {
            var cur = queue.Dequeue();

            var tmp = cur.left;
            cur.left = cur.right;
            cur.right = tmp;

            if (cur.left != null) {
                queue.Enqueue(cur.left);
            }

            if (cur.right != null) {
                queue.Enqueue(cur.right);
            }
        }
        return root;
    }
}