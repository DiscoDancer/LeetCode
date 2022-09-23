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
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if (root == null) {
            return new TreeNode(val, null, null); ;
        }
                
        var cur = root;
        
        while (true) {
            if (val > cur.val) {
                if (cur.right == null) {
                    cur.right = new TreeNode(val, null, null);
                    return root;
                } else {
                    cur = cur.right;
                }
            } else {
                if (cur.left == null) {
                    cur.left = new TreeNode(val, null, null);
                    return root;;
                }
                else {
                    cur = cur.left;
                }
            }
        }
        
        return root;
    }
}