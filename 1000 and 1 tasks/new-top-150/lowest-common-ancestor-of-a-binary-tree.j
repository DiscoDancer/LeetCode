/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */

// naive not effective
class Solution {

    private boolean DoesPathContainWanted(TreeNode root, TreeNode wanted) {
        if (root == null) {
            return false;
        }
        return root == wanted || DoesPathContainWanted(root.left, wanted) || DoesPathContainWanted(root.right, wanted);
    }

    private TreeNode p = null;
    private TreeNode q = null;

    private boolean DoesPathContainP(TreeNode root) {
        return DoesPathContainWanted(root, p);
    }
    private boolean DoesPathContainQ(TreeNode root) {
        return DoesPathContainWanted(root, q);
    }

    private TreeNode result = null;

    private void F(TreeNode root) {
        if (root == null) {
            return;
        }
        if (DoesPathContainP(root) && DoesPathContainQ(root)) {
            result = root;
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