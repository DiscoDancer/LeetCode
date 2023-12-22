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
    // взять все уникальные значения и искать по ним
    // сверху или снизу

    // лист = univalue subtree всегда (даже, если корень)
    // не лист = univalue subtree если 1. дети univalue subtree или пустые 2. значения детей = знанию node или пустые

    private TreeNode _head;
    private int _result = 0;
    private Dictionary<TreeNode, bool> _mem = new ();

    // no nulls
    private void DFS(TreeNode root) {
        if (root.left != null) {
            DFS(root.left);
        }
        if (root.right != null) {
            DFS(root.right);
        }

        if (IsUni(root)) {
            _result++;
        }
    }

    private bool IsUni(TreeNode root) {
        if (_mem.ContainsKey(root)) {
            return _mem[root];
        }

        var isLeftUni = root.left == null || root.left.val == root.val && IsUni(root.left);
        var isRightUni = root.right == null || root.right.val == root.val && IsUni(root.right);

        _mem[root] = isLeftUni && isRightUni;
        return _mem[root];
    }

    // можно попробовать написать рекурсию или мой  же алгоритм с уровнями
    public int CountUnivalSubtrees(TreeNode root) {
        if (root == null) {
            return 0;
        }

        _head = root;
        DFS(root);

        return _result;
    }
}