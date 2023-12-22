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
    // editorial или мое старое
    private int _result = 0;

    private bool DFS (TreeNode root) {
        if (root == null) {
            return true;
        }

        var left = DFS(root.left);
        var right = DFS(root.right);

        if (left && right) {
            if (root.left != null && root.left.val != root.val) {
                return false;
            }
            if (root.right != null && root.right.val != root.val) {
                return false;
            }
            _result++;
            return true;
        }

        return false;
    } 

    public int CountUnivalSubtrees(TreeNode root) {
        DFS(root);
        return _result;
    }
}