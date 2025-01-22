import java.util.LinkedList;
import java.util.Queue;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {
    private static int _max;

    private int F(TreeNode node) {
        if (node == null) {
            return 0;
        }
        if (node.left == null && node.right == null) {
            _max = Math.max(_max, node.val);
            return node.val;
        }
        _max = Math.max(_max, node.val);
        var leftSum = F(node.left);
        var rightSum = F(node.right);

        _max = Math.max(_max, node.val + leftSum + rightSum);

        var valueToReturn = Math.max(node.val, Math.max(node.val + leftSum, node.val + rightSum));

        _max = Math.max(_max, valueToReturn);

        return valueToReturn;
    }

    // root never null
    public int maxPathSum(TreeNode root) {
        _max = root.val;
        return Math.max(F(root), _max);
    }
}