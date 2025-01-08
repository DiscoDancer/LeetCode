import java.util.*;

class Solution {

    private boolean F(TreeNode left, TreeNode right) {
        if (left == null && right == null) {
            return true;
        }
        if (left == null || right == null || left.val != right.val) {
            return false;
        }
        if (left.val != right.val) {
            return false;
        }

        return F(left.left, right.right) && F(left.right, right.left);
    }

    public boolean isSymmetric(TreeNode root) {

        if (root == null) {
            return true;
        }

        return F(root.left, root.right);
    }
}