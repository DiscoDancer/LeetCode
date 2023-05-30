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
    private List<int> _result = new () {};

    private void F(TreeNode node) {
        if (node?.left != null) {
            F(node.left);
        }
        if (node != null) {
            _result.Add(node.val);
        }
        if (node?.right != null) {
            F(node.right);
        }
    }

    public IList<int> InorderTraversal(TreeNode root) {
        F(root);
        return _result;
    }
}