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
    private int F(TreeNode root, int max) {
        var childScore = 0;

        if (root.left != null) {
            childScore += F(root.left, Math.Max(max, root.val));
        }
        if (root.right != null) {
            childScore += F(root.right, Math.Max(max, root.val));
        }

        if (max <= root.val) {
            return 1 + childScore;
        }

        return 0 + childScore;
    }

    // обход дерева с min/max
    public int GoodNodes(TreeNode root) {
        return F(root, int.MinValue);
    }
}