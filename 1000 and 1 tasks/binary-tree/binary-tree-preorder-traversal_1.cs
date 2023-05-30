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

    public IList<int> PreorderTraversal(TreeNode root) {
        var stack = new Stack<TreeNode>();
        if (root != null) {
            stack.Push(root);
        }

        while (stack.Any()) {
            var cur = stack.Pop();
            _result.Add(cur.val);

            if (cur.right != null) {
                stack.Push(cur.right);
            }

            if (cur.left != null) {
                stack.Push(cur.left);
            }
        }

        return _result;
    }
}