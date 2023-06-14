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
    private List<int> _list = new ();

    private void F(TreeNode root) {
        if (root == null) {
            return;
        }


        F(root.left);
        _list.Add(root.val);
        F(root.right);
    }

    public IList<int> InorderTraversal(TreeNode root) {
        F(root);
        return _list;
    }
}