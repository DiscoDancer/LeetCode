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

        
        var min = p.val < q.val ? p : q;
        var max = min == p ? q : p;

        var pathMin = FindPath(root, min);

        var first = pathMin.First();
        var prev = first;
        (int?, int?) span1 = (null, first.val);
        (int?, int?) span2 = (first.val, null);

        foreach (var n in pathMin) {
            if (n == first) {
                prev = n;
                continue;
            }
            if (n == max) {
                return n;
            }

            // диапозоны + n == max

            var isLeft = prev.left == n;
            var isRight = prev.right == n;

            if (isLeft) {
                span1.Item1 = null;
                span1.Item2 = n.val;
                span2.Item1 = n.val;
                span2.Item2 = prev.val;
            } else {
                span1.Item1 = prev.val;
                span1.Item2 = n.val;
                span2.Item1 = n.val;
                span2.Item2 = null;
            }

            // если max попадает в диапозоны, идем дальше
            var goNext1 = true;
            if (span1.Item1.HasValue) {
                goNext1 = goNext1 && max.val > span1.Item1.Value;
            }
            goNext1 = goNext1 && max.val < span1.Item2.Value;


            var goNext2 = true;
            goNext2 = goNext2 && max.val > span2.Item1.Value;
            if (span2.Item2.HasValue) {
                goNext2 = goNext2 && max.val < span2.Item2.Value;
            }
            

            var goNext = goNext1 || goNext2; 
            if (!goNext) {
                return prev;
            }

            prev = n;
        }

        return prev;

    }
}