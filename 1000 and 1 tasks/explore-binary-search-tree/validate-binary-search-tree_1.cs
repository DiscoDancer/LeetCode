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
    public bool IsValidBST(TreeNode root)
    {
        var leftMost = root;
        var stack = new Stack<TreeNode>();

        int? prev = null;

        while (leftMost != null || stack.Any())
        {
            while (leftMost != null)
            {
                stack.Push(leftMost);
                leftMost = leftMost.left;
            }

            var cur = stack.Pop();
            if (prev.HasValue && cur.val <= prev.Value)
            {
                return false;
            }
            prev = cur.val;
            leftMost = cur.right;
        }

        return true;
    }
}