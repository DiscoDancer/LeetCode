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
    public IList<int> PreorderTraversal(TreeNode root) {
        var list = new List<int>();

        if (root == null) {
            return list;
        }

        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Any()) {
            var cur = stack.Pop();
            list.Add(cur.val);

            if (cur.right != null) {
                stack.Push(cur.right);
            }

            if (cur.left != null) {
                stack.Push(cur.left);
            }
        }
        
        return list;
    }
}