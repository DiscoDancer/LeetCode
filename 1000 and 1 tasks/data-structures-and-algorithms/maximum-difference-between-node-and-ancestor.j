import java.util.*;


// самый большой результат будет min - max

class Solution {
    record Entry<A, B, C>(A node, B min, C max) {
    }

    public int maxAncestorDiff(TreeNode root) {
        var queue = new ArrayDeque<Entry<TreeNode, Integer, Integer>>();
        if (root != null) {
            queue.add(new Entry<>(root, root.val, root.val));
        }

        var maxScore = 0;


        while (!queue.isEmpty()) {
            var cur = queue.poll();
            var node = cur.node;
            var min = cur.min;
            var max = cur.max;

            maxScore = Math.max(maxScore, Math.abs(min - max));
            if (node.left != null) {
                queue.add(new Entry<>(node.left, Math.min(min, node.left.val), Math.max(max, node.left.val)));
            }
            if (node.right != null) {
                queue.add(new Entry<>(node.right, Math.min(min, node.right.val), Math.max(max, node.right.val)));
            }
        }

        return maxScore;
    }
}