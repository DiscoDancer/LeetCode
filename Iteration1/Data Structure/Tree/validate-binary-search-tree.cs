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
    private int _rootValue;
    
    public void DFS(TreeNode root, int L, int R) {
        if (!_res) {
            return;
        }
        
        if ( !(L <= root.val && root.val <= R ) ) {
            _res = false;
            return;
        }
        
        if (root.left != null) {
            if (root.left.val < root.val) {
                DFS(root.left, L, root.val - 1);
            }
            else {
                _res = false;
                return;
            }
        }
        
        if (root.right != null) {
            if (root.right.val > root.val) {
                DFS(root.right, root.val + 1, R);
            }
            else {
                _res = false;
                return;
            }
        }
    }
    
    public bool IsValidBST(TreeNode root) {
        if (root == null) {
            return false;
        }
        
        DFS(root, int.MinValue, int.MaxValue);
        
        return _res;
    }
}