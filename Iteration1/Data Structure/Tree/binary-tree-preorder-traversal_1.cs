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
//     private List<int> _res = new List<int>();
    
    
//     public void Preorder(TreeNode root) {
//         if (root != null) {
//             _res.Add(root.val);
            
//             if (root.left != null) {
//                 Preorder(root.left);
//             }
//             if (root.right != null) {
//                 Preorder(root.right);
//             }
//         }

//     }
    
    public IList<int> PreorderTraversal(TreeNode root) {
        // Preorder(root);
        
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        var res = new List<int>();
        
        while (stack.Any()) {
            var cur = stack.Pop();
            if (cur != null) {
                res.Add(cur.val);
                
                if (cur.right != null) {
                    stack.Push(cur.right);
                }
                if (cur.left != null) {
                    stack.Push(cur.left);
                    
                }
            }           
        }
        
        return res;
    }
}