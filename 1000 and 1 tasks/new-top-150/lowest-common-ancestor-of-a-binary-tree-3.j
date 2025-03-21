/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */

// passes 
class Solution {

    public record Tuple<T1, T2>(T1 pFound, T2 qFound) {}

    private Tuple<Boolean, Boolean> DoesPathContainWanted(TreeNode root, int height) {
        if (root == null) {
            return new Tuple<>(false, false);
        }

        var pfound = root == this.p;
        var qfound = root == this.q;

        if (!(pfound && qfound)) {
            var left = DoesPathContainWanted(root.left, height + 1);
            var right = DoesPathContainWanted(root.right, height + 1);

            pfound = pfound || left.pFound || right.pFound;
            qfound = qfound || left.qFound || right.qFound;
        }

        if (pfound && qfound && height > this.resultHeight) {
            this.result = root;
            this.resultHeight = height;
        }

        return new Tuple<>(pfound, qfound);
    }

    private TreeNode p = null;
    private TreeNode q = null;

    private TreeNode result = null;
    private int resultHeight = 0;

    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        this.p = p;
        this.q = q;
        this.result = root;

        DoesPathContainWanted(root, 0);

        return result;
    }
}