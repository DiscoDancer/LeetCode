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

// списал editorial


public class Solution {
    private int _bestNode;
    private double _bestDiff;
    private double _target;

    private void F(TreeNode root) {
        if (root == null) return;

        var diff = Math.Abs(root.val - _target);
        if (diff == _bestDiff && root.val < _bestNode) {
            _bestNode = root.val;
        }
        else if (diff < _bestDiff) {
            _bestDiff = diff;
            _bestNode = root.val;
        }

        if (root.val < _target) {
            F(root.right);
        }
        if (root.val > _target) {
            F(root.left);
        }
    }

    public int ClosestValue(TreeNode root, double target) {
        _target = target;
        _bestDiff = double.MaxValue;
        F(root);

        return _bestNode;
    }
}