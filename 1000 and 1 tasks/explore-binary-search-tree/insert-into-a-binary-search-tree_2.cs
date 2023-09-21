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
public class Solution
{
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root == null)
        {
            return new TreeNode(val);
        }

        var p = root;

        while (true)
        {
            if (val > p.val)
            {
                if (p.right == null)
                {
                    p.right = new TreeNode(val);
                    return root;
                }
                else
                {
                    p = p.right;
                }
            }
            else if (val < p.val)
            {
                if (p.left == null)
                {
                    p.left = new TreeNode(val);
                    return root;
                }
                else
                {
                    p = p.left;
                }
            }
        }

        return root;
    }
}