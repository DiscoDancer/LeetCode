import java.util.*;


class Solution {
    public List<List<Integer>> zigzagLevelOrder(TreeNode root) {
        var result = new ArrayList<List<Integer>>();

        var queue = new ArrayDeque<TreeNode>();
        if (root != null) {
            queue.offer(root);
        }

        var normalOrder = true;
        while (!queue.isEmpty()) {
            var size = queue.size();
            var list = new ArrayList<Integer>();
            for (int i = 0; i < size; i++) {
                var node = queue.poll();

                if (normalOrder) {
                    list.addLast(node.val);
                }
                else {
                    list.addFirst(node.val);
                }

                if (node.left != null) queue.offer(node.left);
                if (node.right != null) queue.offer(node.right);
            }
            normalOrder = !normalOrder;
            result.add(list);
        }

        return result;
    }
}