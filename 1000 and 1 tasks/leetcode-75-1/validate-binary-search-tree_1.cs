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

 // можно проверять по уровням, что там должно все возрастать (этого недостаточно)
 // DFS не подходит, потому что мы то спускаемся, то поднимается



public class Solution {
    public bool IsValidBST(TreeNode root) {

        var p = root;
        var stack = new Stack<TreeNode>();
        var prev = (int?) null;

        while (p != null || stack.Any()) {
            while (p != null) {
                stack.Push(p);
                p = p.left;
            }

            p = stack.Pop();
            if (prev.HasValue && prev.Value >= p.val) {
                return false;
            }

            prev = p.val;
            p = p.right;  
        }

        return true;
    }
}