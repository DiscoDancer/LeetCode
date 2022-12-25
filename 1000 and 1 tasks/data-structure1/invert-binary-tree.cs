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
    // уровень + 2 pointers
    // тоже самое решение, что для симетрик

    private void Invert(TreeNode root) {
        var tmp = root.left;
        root.left = root.right;
        root.right = tmp;

        if (root.left != null) {
            Invert(root.left);
        }
        if (root.right != null) {
            Invert(root.right);
        }
    }

    public TreeNode InvertTree(TreeNode root) {
        if (root == null) {
            return root;
        }

        Invert(root);

        return root;
    }
}