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
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if (root == null) {
            return new TreeNode(val, null, null); ;
        }
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Any()) {
            var cur = queue.Dequeue();
            if (val > cur.val) {
                if (cur.right == null) {
                    cur.right = new TreeNode(val, null, null);
                    break;
                } else {
                    queue.Enqueue(cur.right);
                }
            } else {
                if (cur.left == null) {
                    cur.left = new TreeNode(val, null, null);
                    break;
                }
                else {
                    queue.Enqueue(cur.left);
                }
            }
        }
        
        return root;
    }
}