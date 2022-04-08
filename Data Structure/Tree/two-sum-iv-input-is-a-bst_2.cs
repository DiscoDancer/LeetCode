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
    
    private List<int> _list = new List<int>();
    
    private void Inorder(TreeNode root) {
        if (root == null) {
            return;
        }
        
        Inorder(root.left);
        _list.Add(root.val);
        Inorder(root.right);
    }
    
    public bool FindTarget(TreeNode root, int k) {
        if (root == null || root.left == null && root.right == null) {
            return false;
        }
        
        Inorder(root);
        
        var arr = _list.ToArray();
        var L = 0;
        var R = arr.Length - 1;
        
        while (L < R) {  
            var sum = arr[L] + arr[R];
            
            if (sum == k) {
                return true;
            }
            
            if (sum < k) {
                L++;
            } else {
                R--;
            }
        }
        
        return false;
    }
}