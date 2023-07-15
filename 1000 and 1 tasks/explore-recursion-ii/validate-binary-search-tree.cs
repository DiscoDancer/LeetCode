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
    public bool IsValidBST(TreeNode root) {
        var list = new List<int>();

        var stack = new Stack<TreeNode>();
        var left = root;

        // inorder
        while (left != null || stack.Any()){
            while (left != null)
            {
                stack.Push(left);
                left = left.left;
            }
            var top = stack.Pop();
            list.Add(top.val);
            left = top.right;
        }

        var prev = list[0];
        for (int i = 1; i < list.Count(); i++) {
            var cur = list[i];
            if (prev >= cur) {
                return false;
            }
            prev = cur;
        }

        return true;
    }
}