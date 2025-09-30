import java.util.*;

// всегда можно вставить, балансировать не надо

class Solution {
    public TreeNode insertIntoBST(TreeNode root, int val) {

        if (root == null) {
            return new TreeNode(val);
        }

        var node = root;
        while (true) {
            if (val < node.val) {
                if (node.left == null) {
                    node.left = new TreeNode(val);
                    break;
                }
                else {
                    node = node.left;
                }
            }
            else if (val > node.val) {
                if (node.right == null) {
                    node.right = new TreeNode(val);
                    break;
                }
                else {
                    node = node.right;
                }
            }
        }

        return root;
    }
}