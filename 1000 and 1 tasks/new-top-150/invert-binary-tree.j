import java.util.*;

class Solution {
    public TreeNode invertTree(TreeNode root)  {
        Queue<TreeNode> queue = new LinkedList<>();

        if (root != null) {
            queue.add(root);
        }

        while (!queue.isEmpty()) {
            TreeNode current = queue.poll();
            TreeNode temp = current.left;
            current.left = current.right;
            current.right = temp;

            if (current.left != null) {
                queue.add(current.left);
            }

            if (current.right != null) {
                queue.add(current.right);
            }
        }

        return root;
    }
}