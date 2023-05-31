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

    // reversed preorder
    public IList<int> PostorderTraversal(TreeNode root) {
        var stack = new Stack<TreeNode>();
        if (root != null) {
            stack.Push(root);
        }

        while (stack.Any()) {
            var cur = stack.Pop();
            _list.Insert(0, cur.val);

            
            if (cur.left != null) {
                stack.Push(cur.left);
            }

            if (cur.right != null) {
                stack.Push(cur.right);
            }
        }

        return _list;
    }
}