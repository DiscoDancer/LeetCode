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
    public TreeNode SearchBST(TreeNode root, int val) {

        
           var cur = root;
        
           while (cur != null) {
               if (cur.val == val) {
                   return cur;
               }
               if (cur.left != null && cur.val > val) {
                   cur = cur.left;
               }
               else {
                   cur = cur.right;
               }
           }
        
           return cur;
    }
}