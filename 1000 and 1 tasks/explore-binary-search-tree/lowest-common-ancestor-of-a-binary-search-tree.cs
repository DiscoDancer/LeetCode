/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    // пока что-то выполняется, спускаемся вниз
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var lowest = root;

        while (p.val < lowest.val && q.val < lowest.val || p.val > lowest.val && q.val > lowest.val) {
            if (p.val < lowest.val && q.val < lowest.val) {
                lowest = lowest.left;
            }
            else if (p.val > lowest.val && q.val > lowest.val) {
                lowest = lowest.right;
            }
        }

        return lowest;
    }
}