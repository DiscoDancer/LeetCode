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
    public bool HasPathSum(TreeNode root, int targetSum) {
        // add link to parents + memory
        // find all leafs // O(n) + memory
        // calc all leafes // n*Log(n)
        
        // можно сумму как высоту писать на node через рекурсию, тогда до листа сразу дойдет сумма
        // если нужна не дошла, то false
    }
}