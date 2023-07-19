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

    private List<int> _result = new ();

    private void Inorder(TreeNode root) {
        if (root.left != null) {
            Inorder(root.left);
        }

        _result.Add(root.val);

        if (root.right != null) {
            Inorder(root.right);
        }
    }

    public IList<int> InorderTraversal(TreeNode root) {
        if (root != null) {
            Inorder(root);
        }

        return _result;
    }
}