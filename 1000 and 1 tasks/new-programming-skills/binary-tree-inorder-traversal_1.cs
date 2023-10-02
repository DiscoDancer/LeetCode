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
    public IList<int> InorderTraversal(TreeNode root) {
        var leftMost = root;
        var stack = new Stack<TreeNode>();

        var result = new List<int>();

        while (leftMost != null || stack.Any()) {
            while (leftMost != null) {
                stack.Push(leftMost);
                leftMost = leftMost.left;
            }

            leftMost = stack.Pop();
            result.Add(leftMost.val);
            leftMost = leftMost.right;
        }

        return result;
    }
}