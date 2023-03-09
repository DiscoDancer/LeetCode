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
    private int _index = 0;
    private int _k;
    private int? _result = null;

    private void Inorder(TreeNode root) {
        if (_result != null) {
            return;
        }

        if (root.left != null) {
            Inorder(root.left);
        }

        _index++;
        if (_index == _k) {
            _result = root.val;
        }

        if (root.right != null) {
            Inorder(root.right);
        }
    }

    // inorder with stop
    public int KthSmallest(TreeNode root, int k) {
        _k = k;
        Inorder(root);
        return _result.Value;
    }
}