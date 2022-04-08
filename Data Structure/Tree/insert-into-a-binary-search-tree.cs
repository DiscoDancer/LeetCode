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
    public void Triangle(TreeNode root, int val) {
        if (val > root.val) {
            if (root.right == null) {
                root.right = new TreeNode(val, null, null);
                return;
            } else {
                Triangle(root.right, val);
            }
        }
        if (val < root.val) {
            if (root.left == null) {
                root.left = new TreeNode(val, null, null);
                return;
            }
            else {
                Triangle(root.left, val);
            }
        }
    }
    
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if (root == null) {
            return new TreeNode(val, null, null); ;
        }
        
        Triangle(root, val);
        
        return root;
    }
}