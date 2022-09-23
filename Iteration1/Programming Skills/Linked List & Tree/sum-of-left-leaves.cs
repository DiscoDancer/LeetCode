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
    public int SumOfLeftLeaves(TreeNode root) {
        if (root == null) {
            return 0;
        }
                
        var queue = new Queue<TreeNode>();
        var res = 0;
        queue.Enqueue(root);
        
        while (queue.Any()) {
            var cur = queue.Dequeue();
            
            if (cur.left != null) {
                queue.Enqueue(cur.left);
                
                if (cur.left.left == null && cur.left.right == null) {
                    res += cur.left.val;
                }
            }
            if (cur.right != null) {
                queue.Enqueue(cur.right);
            }
        }
        
        return res;
        
    }
}