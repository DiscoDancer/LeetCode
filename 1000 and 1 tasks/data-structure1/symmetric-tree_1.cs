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
    // сразу видно, что мой алгоритм по уровням не зайдет
    // точнее зайдет, но придется R и L хранить

    public bool IsSymmetric(TreeNode root) {

        var stackL = new Stack<TreeNode>();
        var stackR = new Stack<TreeNode>();
        stackL.Push(root);
        stackR.Push(root);

        while (stackL.Any() && stackR.Any()) {
            var curL = stackL.Pop();
            var curR = stackR.Pop();

            if (curL.right != null) {
                if (curR.left == null || curR.left.val != curL.right.val) {
                    return false;
                }
                stackL.Push(curL.right);
                stackR.Push(curR.left);
            }
            if (curL.left != null) {
                if (curR.right == null || curR.right.val != curL.left.val) {
                    return false;
                }
                stackL.Push(curL.left);
                stackR.Push(curR.right);
            }
        }

        return !stackL.Any() && !stackR.Any();
    }
}