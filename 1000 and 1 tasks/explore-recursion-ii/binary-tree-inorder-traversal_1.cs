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
        var result = new List<int>();

        var stack = new Stack<TreeNode>();
        var left = root;

        while (left != null || stack.Any()) {
            while (left != null) {
                stack.Push(left);
                left = left.left;
            }

            var cur = stack.Pop();
            result.Add(cur.val);
            left = cur.right;
        }

        return result;
    }
}