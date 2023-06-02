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
    private int _result = 0;

    public bool IsValid(TreeNode node, int val) {
        if (node.val != val) {
            return false;
        }

        var left = true;
        if (node.left != null) {
            left = IsValid(node.left, val);
        }

        var right = true;
        if (node.right != null) {
            right = IsValid(node.right, val);
        }

        return left && right;
    }

    public void DFS(TreeNode root) {
        if (root == null) {
            return;
        }
        DFS(root.left);
        DFS(root.right);
        if (IsValid(root, root.val)) {
            _result++;
        }
    }

    public int CountUnivalSubtrees(TreeNode root) {
        DFS(root);
        return _result;
    }
}