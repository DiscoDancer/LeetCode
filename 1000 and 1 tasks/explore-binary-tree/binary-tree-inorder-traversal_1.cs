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
    public IList<int> InorderTraversal(TreeNode root) {
        var current = root;
        var stack = new Stack<TreeNode>();

        while (current != null || stack.Any()) {
            while (current != null) {
                stack.Push(current);
                current = current.left;
            }
            current = stack.Pop();
            _result.Add(current.val);
            current = current.right;
        }

        return _result;
    }
}