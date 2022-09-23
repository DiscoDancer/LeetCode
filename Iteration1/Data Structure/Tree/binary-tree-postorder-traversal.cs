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
    private List<int> _res = new List<int>();
    
    private void Postorder(TreeNode node) {
        if (node != null) {
            if (node.left != null) {
                Postorder(node.left);
            }
            if (node.right != null) {
                Postorder(node.right);
            }
            _res.Add(node.val);
        }
    }
    
    public IList<int> PostorderTraversal(TreeNode root) {
        Postorder(root);
        
        return _res;
    }
}