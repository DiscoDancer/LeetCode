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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var cur = root;

        while (true) {
            if (p.val > cur.val && q.val > cur.val) {
                cur = cur.right;
                continue;
            }
            if (p.val < cur.val && q.val < cur.val) {
                cur = cur.left;
                continue;
            }
            break;
        }

        return cur;
    }
}