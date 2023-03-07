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

// высота 2х поддерьев не больше 1 разница 
public class Solution {
    private bool _result = true;

    private int Height(TreeNode root) {
        if (root == null) {
            return 0;
        }

        var left = Height(root.left);
        var right = Height(root.right);

        _result = Math.Abs(left - right) <= 1 && _result;

        return 1 + Math.Max(left, right);
    }

    public bool IsBalanced(TreeNode root) {
        Height(root);
        return _result;
    }
}