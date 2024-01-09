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
    public int ClosestValue(TreeNode root, double target) {
        var bestDistance = double.MaxValue;
        var bestVal = int.MaxValue;

        var p = root;
        while (p != null) {
            var curDistance = Math.Abs((double)p.val - target);
            if (curDistance < bestDistance) {
                bestDistance = curDistance;
                bestVal = p.val;
            }
            else if (curDistance == bestDistance && p.val < bestVal) {
                bestVal = p.val;
            }

            if (p.left != null && target <= p.val) {
                p = p.left;
            }
            else if (p.right != null && target > p.val) {
                p = p.right;
            }
            else {
                p = null;
            }
        }

        return bestVal;
    }
}