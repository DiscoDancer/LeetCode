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
    
    public bool FindBST(TreeNode root, int x) {
        var cur = root;
        
        while (cur != null) {
            if (x == cur.val) {
                return true;
            }
            
            if (x < cur.val) {
                cur = cur.left;
            }
            else {
                cur = cur.right;
            }
        }
        
        return false;
    }
    
    public bool FindTarget(TreeNode root, int k) {
        if (root == null || root.left == null && root.right == null) {
            return false;
        }
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Any()) {
            var cur = queue.Dequeue();
            var x = k - cur.val;
            
            if (x != cur.val && FindBST(root, x)) {
                return true;
            }
            
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