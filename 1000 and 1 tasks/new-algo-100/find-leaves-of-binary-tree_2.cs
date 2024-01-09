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

// editorial
 
public class Solution {
    private List<IList<int>> _result = new ();

    private int getHeight(TreeNode root) {
        // return -1 for null nodes
        if (root == null) {
            return -1;
        }

        // first calculate the height of the left and right children
        int leftHeight = getHeight(root.left);
        int rightHeight = getHeight(root.right);

        int currHeight = Math.Max(leftHeight, rightHeight) + 1;

        if (this._result.Count() == currHeight) {
            this._result.Add(new List<int>());
        }

        this._result[currHeight].Add(root.val);
        
        return currHeight;
    }

    public IList<IList<int>> FindLeaves(TreeNode root) {
        getHeight(root);
        return _result;
    }
}