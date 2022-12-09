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

 // можно проверять по уровням, что там должно все возрастать (этого недостаточно)
 // DFS не подходит, потому что мы то спускаемся, то поднимается



public class Solution {

    private bool _hasPrev = false;
    private int _prev = -1;
    private bool _res = true;

    public void InOrder(TreeNode node) {
        if (!_res) {
            return;
        }

        if (node.left != null) {
            InOrder(node.left);
        }

        if (!_hasPrev) {
            _hasPrev = true;
        }
        else {
            if (_prev >= node.val) {
                _res = false;
            }
        }
        _prev = node.val;

        if (node.right != null) {
            InOrder(node.right);
        }
    }

    public bool IsValidBST(TreeNode root) {
        InOrder(root);

        return _res;
    }
}