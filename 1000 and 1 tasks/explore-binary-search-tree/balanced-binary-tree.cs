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

    private bool _OK = true;

    public int GetHeight(TreeNode root) {
        if (!_OK) {
            return -1;
        }

        if (root == null) {
            return 0;
        }

        var L = GetHeight(root.left);
        var R = GetHeight(root.right);

        if (Math.Abs(L - R) > 1) {
            _OK = false;
            return -1;
        }

        return 1 + Math.Max(L,R);
    }

    public bool IsBalanced(TreeNode root) {
        GetHeight(root);

        return _OK;
    }
}