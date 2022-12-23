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

    public void PreorderTraversalInner(TreeNode root) {
        _list.Add(root.val);
        if (root.left != null) {
            PreorderTraversalInner(root.left);
        }
        if (root.right != null) {
            PreorderTraversalInner(root.right);
        }
    }

    public IList<int> PreorderTraversal(TreeNode root) {
        if (root != null) {
            PreorderTraversalInner(root);
        }
        
        return _list;
    }
}