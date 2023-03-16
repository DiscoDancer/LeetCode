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
    // сразу видно, что мой алгоритм по уровням не зайдет
    // точнее зайдет, но придется R и L хранить

    private bool _res = true;

    public void PreorderRL(TreeNode rootL, TreeNode rootR) {
        if (!_res) {
            return;
        }

        if (rootL.left != null) {
            if (rootR.right == null || rootL.left.val != rootR.right.val) {
                _res = false;
                return;
            }

            PreorderRL(rootL.left, rootR.right);
        }

        if (rootL.right != null) {
            if (rootR.left == null || rootL.right.val != rootR.left.val) {
                _res = false;
                return;
            }

            PreorderRL(rootL.right, rootR.left);
        }
    }

    // мое старое решение
    public bool IsSymmetric(TreeNode root) {
        PreorderRL(root, root);
        return _res;
    }
}