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
    
//     private List<int> _list = new List<int>();
    
//     private void Inorder(TreeNode root) {
//         if (root != null) {
//             if (root.left != null) {
//                 Inorder(root.left);
//             }
//             _list.Add(root.val);
//             if (root.right != null) {
//                 Inorder(root.right);
//             } 
//         }
        

        
//     }
    
    public IList<int> InorderTraversal(TreeNode root) {
        // Inorder(root);
        
        var list = new List<int>(); // replace with stack queue or and reverse
        var stack = new Stack<TreeNode>();
        
        var cur = root;
        
        while (cur != null || stack.Any()) {
            while (cur != null) {
                stack.Push(cur);
                cur = cur.left;
            }
            cur = stack.Pop();
            list.Add(cur.val);
            cur = cur.right;
        }
        
        
        return list;
    }
}