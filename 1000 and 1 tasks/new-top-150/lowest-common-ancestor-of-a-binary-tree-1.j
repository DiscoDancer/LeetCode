/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
class Solution {

    // TL
    public record Tuple<T1, T2>(T1 pFound, T2 qFound) {}

    private Tuple<Boolean, Boolean> DoesPathContainWanted(TreeNode root) {
        if (root == null) {
            return new Tuple<>(false, false);
        }

        var pfound = root == this.p || DoesPathContainWanted(root.left).pFound || DoesPathContainWanted(root.right).pFound;
        var qfound = root == this.q || DoesPathContainWanted(root.left).qFound || DoesPathContainWanted(root.right).qFound;

        return new Tuple<>(pfound, qfound);
    }

    private TreeNode p = null;
    private TreeNode q = null;

    private TreeNode result = null;

    private void F(TreeNode root) {
        if (root == null) {
            return;
        }

        var doesPathContainWanted = DoesPathContainWanted(root);
        if (doesPathContainWanted.pFound && doesPathContainWanted.qFound) {
            this.result = root;
        }

        F(root.left);
        F(root.right);
    }



    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        this.p = p;
        this.q = q;

        F(root);
        // return lowestCommonAncestor(root);

        return result;
    }
}