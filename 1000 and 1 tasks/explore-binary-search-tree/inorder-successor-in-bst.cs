/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {

    // см. решение validate-binary-search-tree.cs
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        var leftMost = root;
        var stack = new Stack<TreeNode>();

        TreeNode? prev = null;

        while (leftMost != null || stack.Any())
        {
            while (leftMost != null)
            {
                stack.Push(leftMost);
                leftMost = leftMost.left;
            }

            var cur = stack.Pop();
            if (p == prev) {
                return cur;
            }
            prev = cur;

            leftMost = cur.right;
        }

        return null;
    }
}