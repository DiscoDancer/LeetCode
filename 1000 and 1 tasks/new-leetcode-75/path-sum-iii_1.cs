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
    // надо делать смещение, чтобы по несколько раз не считать
    // или просто в табличку ебнуть (2 цвета)

    // другая функция, которая начинает путь с каждого узла

    private int _result = 0;
    private int _targetSum;

    private void Traverse(TreeNode node) {
        if (node.left != null) {
            Traverse(node.left);
        }
        if (node.right != null) {
            Traverse(node.right);
        }

        Proccess(node, 0l);
    }

    private void Proccess(TreeNode node, long acc) {
        if (node.left != null) {
            Proccess(node.left, acc + node.val);
        }
        if (node.right != null) {
            Proccess(node.right, acc + node.val);
        }

        if (acc + node.val == _targetSum) {
            _result++;
        }
    }

    public int PathSum(TreeNode root, int targetSum) {
        _targetSum = targetSum;
        if (root != null) {
            Traverse(root);
        }

        return _result;
    }
}