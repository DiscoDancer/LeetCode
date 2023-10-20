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
    // за квадрат изи
    // звучит как DP

    public const int PARENT_LEFT = 1;
    public const int PARENT_RIGHT = 2;

    private int _max = 0;

    private void Traverse(TreeNode node) {
        if (node.left != null) {
            Traverse(node.left);
        }
        if (node.right != null) {
            Traverse(node.right);
        }

        Proccess(node, 0, 0);
    }

    private void Proccess(TreeNode node, int acc, int parentState) {
        if (node.left != null) {
            var newAcc = parentState != PARENT_LEFT ? acc + 1 : 0;
            Proccess(node.left, newAcc, PARENT_LEFT);
        }
        if (node.right != null) {
            var newAcc = parentState != PARENT_RIGHT ? acc + 1 : 0;
            Proccess(node.right, newAcc, PARENT_RIGHT);
        }

        _max = Math.Max(_max, acc);
    }

    // TL
    public int LongestZigZag(TreeNode root) {
        Traverse(root);

        return _max;
    }
}