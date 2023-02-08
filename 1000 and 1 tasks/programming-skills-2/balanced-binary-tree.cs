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
    private bool _res = true;

    public int f(TreeNode root) {
        if (root == null) {
            return 0;
        }
        if (root.left == null && root.right == null) {
            return 1;
        }
        
        var l = f(root.left);
        var r = f(root.right);

        if (Math.Abs(l-r) > 1) {
            _res = false;
        }

        return Math.Max(l,r) + 1;
    }

    // высота поддерева не больше 1
    public bool IsBalanced(TreeNode root) {
        if (root == null) {
            return true;
        }
        f(root);

        return _res;
    }
}