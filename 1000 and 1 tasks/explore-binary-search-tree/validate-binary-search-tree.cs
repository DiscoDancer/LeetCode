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
    private bool _isValid = true;
    private int? _prev = null;

    private void F(TreeNode root) {
        if (!_isValid) return;

        if (root.left != null) F(root.left);

        var curVal = root.val;
        if (_prev != null && _prev.Value >= curVal) {
            _isValid = false;
            return;
        }
        _prev = curVal;

        if (root.right != null) F(root.right);
    }


    public bool IsValidBST(TreeNode root) {

        F(root);

        return _isValid;
    }
}