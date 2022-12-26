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

    private List<TreeNode> GetPath(TreeNode root, TreeNode p) {
        var res = new List<TreeNode>();

        var cur = root;

        while (true) {
            res.Add(cur);
            if (cur == p) {
                break;
            }

            if (p.val < cur.val) {
                cur = cur.left;
            } else {
                cur = cur.right;
            }
        }

        return res;
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var pathP = GetPath(root, p).ToArray();
        var pathQ = GetPath(root, q).ToArray();

        var i = 0;

        while (i < pathP.Length && i < pathQ.Length && pathP[i] == pathQ[i]) {
            i++;
        }

        return pathP[i-1];
    }
}