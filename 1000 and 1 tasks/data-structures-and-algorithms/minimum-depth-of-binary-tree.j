import java.util.*;


class Solution {
    record Pair<A, B>(A first, B second) {
    }

    public int minDepth(TreeNode root) {
        var queue = new ArrayDeque<Pair<TreeNode, Integer>>();
        if (root != null) {
            queue.add(new Pair<>(root, 0));
        }

        var minDepth = Integer.MAX_VALUE;


        while (!queue.isEmpty()) {
            var cur = queue.poll();
            var node = cur.first;
            var parentDepth = cur.second;
            var depth = parentDepth + 1;

            if (node.left == null && node.right == null) {
                minDepth = Math.min(minDepth, depth);
            } else {
                if (node.left != null) {
                    queue.add(new Pair<>(node.left, depth));
                }
                if (node.right != null) {
                    queue.add(new Pair<>(node.right, depth));
                }
            }
        }

        return minDepth == Integer.MAX_VALUE ? 0 : minDepth;
    }
}