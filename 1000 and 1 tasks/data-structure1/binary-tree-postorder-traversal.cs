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

    public void PostorderTraversalInner(TreeNode root) {
        if (root.left != null) {
            PostorderTraversalInner(root.left);
        }
        if (root.right != null) {
            PostorderTraversalInner(root.right);
        }

        _list.Add(root.val);
    }

    public IList<int> PostorderTraversal(TreeNode root) {
        if (root != null) {
            PostorderTraversalInner(root);
        }
        
        return _list;
    }
}