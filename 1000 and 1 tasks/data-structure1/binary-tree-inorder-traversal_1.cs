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
        if (root == null) {
            return new List<int>();
        }

        var list = new List<int>();
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Any()) {
            var top = stack.Peek();
            if (top.left != null) {
                while (top.left != null) {
                    stack.Push(top.left);
                    var tmp = top;
                    top = top.left;
                    tmp.left = null;
                }
                continue;
            }

            var cur = stack.Pop();
            list.Add(cur.val);

            if (cur.right != null) {
                stack.Push(cur.right);
            }
        }

        return list;
    }
}