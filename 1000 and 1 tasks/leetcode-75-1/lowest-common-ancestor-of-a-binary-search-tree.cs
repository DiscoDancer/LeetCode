/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

/*
    Roadmap:
    - решить тупо
*/

public class Solution {

    // x != root
    public List<TreeNode> FindPath(TreeNode root, TreeNode x) {
        var p = root;

        var res = new List<TreeNode>();

        while (p != x) {
            res.Add(p);
            if (p.val < x.val) {
                p = p.right;
            }
            else if (p.val > x.val) {
                p = p.left;
            }
        }
        res.Add(x);

        return res;
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null || root == p || root == q) {
            return root;
        }

        if (p == q) {
            return p;
        }

        var pathP = FindPath(root, p);
        var pathQ = FindPath(root, q);

        var set = new HashSet<TreeNode>();
        foreach (var n in pathP) {
            set.Add(n);
        }

        pathQ.Reverse();

        foreach (var n in pathQ) {
            if (set.Contains(n)) {
                return n;
            }
        }

        return null;

    }
}