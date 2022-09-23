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
    private int _targetSum;
    private bool _res = false;
    
    public void DFS(TreeNode root, int accum) {
        if (_res) {
            return;
        }
        
        if (root.left == null && root.right == null) {
            if (root.val + accum == _targetSum) {
                _res = true;
            }
        }
        
        if (root.left != null) {
            DFS(root.left, accum + root.val);
        }
        if (root.right != null) {
            DFS(root.right, accum + root.val);
        }
    }
    
    public bool HasPathSum(TreeNode root, int targetSum) {
        if (root == null) {
            return false;
        }
        
        _targetSum = targetSum;
        DFS(root, 0);
        return _res;
        // можно сумму как высоту писать на node через рекурсию, тогда до листа сразу дойдет сумма    
    }
}