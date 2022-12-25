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

    private List<int> _list = new List<int>();

    public void PostorderTraversalInner(TreeNode root) {
        if (root.left != null) {
            PostorderTraversalInner(root.left);
        }
        if (root.right != null) {
            PostorderTraversalInner(root.right);
        }

        _list.Add(root.val);
    }

    public IList<int> PostorderTraversal(TreeNode root) {
        if (root == null) {
            return new List<int>();
        }

        var stack = new Stack<TreeNode>();
        stack.Push(root);

        var list = new List<int>();

        while (stack.Any()) {
            var top = stack.Peek();
            if (top.left != null) {
                while (top.left != null) {
                    var prev = top;
                    stack.Push(top.left);
                    top = top.left;
                    prev.left = null;
                }
                continue;
            }

            if (top.right != null) {
                var prev = top;
                stack.Push(top.right);
                top = top.right;
                prev.right = null;
                
                continue;
            }

            var cur = stack.Pop();
            list.Add(cur.val);
        }
        
        return list;
    }
}