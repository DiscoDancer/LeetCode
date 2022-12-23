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

    private void InorderTraversalInner(TreeNode root) {
        if (root.left != null) {
            InorderTraversalInner(root.left);
        }
        _list.Add(root.val);
        if (root.right != null) {
            InorderTraversalInner(root.right);
        }
    }

    public IList<int> InorderTraversal(TreeNode root) {
        if (root == null) {
            return _list;
        }
        InorderTraversalInner(root);
        return _list;
    }
}