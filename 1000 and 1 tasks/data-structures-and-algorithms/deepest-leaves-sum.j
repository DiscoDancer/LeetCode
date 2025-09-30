import java.util.*;

// basic algorithm

class Solution {
    public int deepestLeavesSum(TreeNode root) {
        var queue = new ArrayDeque<TreeNode>();
        if (root != null) {
            queue.offer(root);
        }

        var sum = 0;

        while (!queue.isEmpty()) {
            var size = queue.size();
            sum = 0;
            for (int i = 0; i < size; i++) {
                var node = queue.poll();
                sum += node.val;
                if (node.left != null) queue.offer(node.left);
                if (node.right != null) queue.offer(node.right);
            }
        }

        return sum;
    }
}