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
    // при определенном обходе порядок по неубыванию
    // можно собрать массив, а можно хранить только prev
    // и это inorder

    private bool _result = true;
    private int? previousValue = null;

    private void Inorder(TreeNode root) {
        if (!_result) {
            return;
        }

        if (root.left != null) {
            Inorder(root.left);
        }
        if (previousValue != null) {
            if (previousValue.Value >= root.val) {
                _result = false;
                return;
            }
        }
        previousValue = root.val;
        if (root.right != null) {
            Inorder(root.right);
        }
    }

    public bool IsValidBST(TreeNode root) {
        if (root == null) {
            return false;
        }

        Inorder(root);

        return _result;
    }
}