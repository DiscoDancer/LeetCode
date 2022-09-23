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
           if (root == null) {
               return null;
           }
        
           var queue = new Queue<TreeNode>();
           queue.Enqueue(root);
        
           while (queue.Any()) {
               var cur = queue.Dequeue();
               
               if (cur.val == val) {
                   return cur;
               }
               
               if (cur.left != null && cur.val > val) {
                    queue.Enqueue(cur.left);
               }
               else if (cur.right != null && cur.val < val) {
                    queue.Enqueue(cur.right);
               }
           }
        
            return null;
            
        
//         if (root.val == val) {
//             return root;
//         }
        
//         TreeNode res = null;
        
//         if (root.left != null && root.val > val) {
//             res = SearchBST(root.left, val);
//             if (res != null) {
//                 return res;
//             }
//         }
        
//         if (root.right != null && root.val < val) {
//             res = SearchBST(root.right, val);
//             if (res != null) {
//                 return res;
//             }
//         }
        
//         return res;
    }
}