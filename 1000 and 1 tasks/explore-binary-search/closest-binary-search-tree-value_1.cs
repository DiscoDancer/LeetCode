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

// edtiorial
public class Solution {
    public int ClosestValue(TreeNode root, double target) {
        var p = root;
        var diff = Math.Abs(root.val - target);

        var bestDiff = diff;
        var bestNode = p.val;
        
        while (p != null) {
            if (Math.Abs(p.val - target) == bestDiff && p.val < bestNode) {
                bestNode = p.val;
            }
            else if (Math.Abs(p.val - target) < bestDiff ) {
                bestDiff = Math.Abs(p.val - target);
                bestNode = p.val;
            }

            if (p.val < target) {
                p = p.right;
            }
            else {
                p = p.left;
            }
        }

        return bestNode;
    }
}