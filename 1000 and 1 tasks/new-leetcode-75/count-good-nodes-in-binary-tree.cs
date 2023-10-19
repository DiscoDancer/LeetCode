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

    private int _count = 0;

    private void F(TreeNode root, int max) {
        if (root.left != null) {
            F(root.left, Math.Max(max, root.val));
        }
        if (root.right != null) {
            F(root.right, Math.Max(max, root.val));
        }

        if (max <= root.val) {
            _count++;
        }
    }

    // обход дерева с min/max
    public int GoodNodes(TreeNode root) {
        F(root, int.MinValue);

        return _count;
    }
}