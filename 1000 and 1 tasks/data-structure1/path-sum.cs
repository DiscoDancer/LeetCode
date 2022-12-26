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

    private bool _res = false;
    private int _targetSum;

    public void HasPathSumInner(TreeNode root, int acc = 0) {
        if (_res) {
            return;
        }

        if (root.left == null && root.right == null && acc + root.val == _targetSum) {
            _res = true;
            return;
        }

        if (root.left != null) {
            HasPathSumInner(root.left, acc + root.val);
        }

        if (root.right != null) {
            HasPathSumInner(root.right, acc + root.val);
        }
    }

    public bool HasPathSum(TreeNode root, int targetSum) {
        if (root == null) {
            return false;
        }

        _targetSum = targetSum;

        HasPathSumInner(root);

        return _res;
    }
}