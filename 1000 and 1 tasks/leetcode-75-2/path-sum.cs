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
    private int _targetSum;
    private bool _found = false;

    public void TopDown(TreeNode root, int cur) {
        if (root == null || _found) {
            return;
        }

        var newCur = cur + root.val;
        if (newCur == _targetSum && root.left == null && root.right == null) {
            _found = true;
            return;
        }

        TopDown(root.left, newCur);
        TopDown(root.right, newCur);
    }

    // идем сверху вниз, перебираем суммы
    public bool HasPathSum(TreeNode root, int targetSum) {
        _targetSum = targetSum;
        TopDown(root, 0);
        return _found;
    }
}