import java.util.LinkedList;
import java.util.Queue;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * int val;
 * TreeNode left;
 * TreeNode right;
 * TreeNode() {}
 * TreeNode(int val) { this.val = val; }
 * TreeNode(int val, TreeNode left, TreeNode right) {
 * this.val = val;
 * this.left = left;
 * this.right = right;
 * }
 * }
 */
class Solution {
    public int sumNumbers(TreeNode root) {
        var result = 0;

        Queue<TreeNode> queue = new LinkedList<>();
        if (root != null) {
            queue.add(root);
        }

        while (!queue.isEmpty()) {
            var size = queue.size();
            for (int i = 0; i < size; i++) {
                var node = queue.poll();
                if (node.left == null && node.right == null) {
                    result += node.val;
                } else {
                    if (node.left != null) {
                        node.left.val = node.val * 10 + node.left.val;
                        queue.offer(node.left);
                    }
                    if (node.right != null) {
                        node.right.val = node.val * 10 + node.right.val;
                        queue.offer(node.right);
                    }
                }
            }
        }

        return result;
    }
}