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
    private int _result = 0;
    private int _targetSum;

    private HashSet<TreeNode> _calc = new ();

    private void F(TreeNode node, long acc, bool scratch) {
        if (scratch) {
            if (_calc.Contains(node)) {
                return;
            }
            _calc.Add(node);
        }

        if (node.left != null) {
            F(node.left, acc + node.val, false);
            F(node.left, 0, true);
        }
        if (node.right != null) {
            F(node.right, acc + node.val, false);
            F(node.right, 0, true);
        }

        if (acc + node.val == _targetSum) {
            _result++;
        }
    }

    // оно проходит, но оно так себе
    public int PathSum(TreeNode root, int targetSum) {
        _targetSum = targetSum;
        if (root != null) {
            F(root, 0l, true);
        }

        return _result;
    }
}