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
    public bool IsValidBST(TreeNode root) {
        if (root == null) {
            return false;
        }
        
        var queue = new Queue<(TreeNode node, int l, int r)>();
        queue.Enqueue((root, int.MinValue, int.MaxValue));

        while (queue.Any()) {
            var cur = queue.Dequeue();
            
            if ( !(cur.l <= cur.node.val && cur.node.val <= cur.r ) ) {
                return false;
            }
            
            if (cur.node.left != null) {
                if (cur.node.left.val < cur.node.val) {
                    queue.Enqueue((cur.node.left, cur.l, cur.node.val - 1));
                } else {
                    return false;
                }
            }
            
            if (cur.node.right != null) {
                if (cur.node.right.val > cur.node.val) {
                    queue.Enqueue((cur.node.right, cur.node.val + 1, cur.r));
                } else {
                    return false;
                }
            }
        }
        
        return true;
    }
}