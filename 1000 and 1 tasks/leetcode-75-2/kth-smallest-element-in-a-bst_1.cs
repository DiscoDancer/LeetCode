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
    // https://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion/
    public int KthSmallest(TreeNode root, int k) {
        var stack = new Stack<TreeNode>();
        var cur = root;

        var index = 0;

        while (cur != null || stack.Any()) {
            while (cur != null) {
                stack.Push(cur);
                cur = cur.left;
            }

            cur = stack.Pop();
            if (++index == k) {
                return cur.val;
            }

            cur = cur.right;
        }

        return -1; // not possible
    }
}