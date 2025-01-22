import java.util.LinkedList;
import java.util.Queue;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {

    private class CustomTreeNode {
        public int maxPathSum;
        public TreeNode treeNode;
        public boolean visited;
        public CustomTreeNode parent;
        public CustomTreeNode left;
        public CustomTreeNode right;
        public CustomTreeNode(TreeNode treeNode, CustomTreeNode parent) {
            this.treeNode = treeNode;
            this.visited = false;
            this.maxPathSum = treeNode.val;
            this.parent = parent;
            this.left = null;
            this.right = null;
        }
    }

    // root never null
    public int maxPathSum(TreeNode root) {

        // todo wrap the tree

        Queue<CustomTreeNode> queue = new LinkedList<>();
        CustomTreeNode customRoot = new CustomTreeNode(root, null);
        queue.add(customRoot);


        Queue<CustomTreeNode> leafQueue = new LinkedList<>();

        var maxValue = Integer.MIN_VALUE;

        while (!queue.isEmpty()) {
            var size = queue.size();
            for (int i = 0; i < size; i++) {
                var cur = queue.poll();
                if (cur.treeNode.left == null && cur.treeNode.right == null) {
                    leafQueue.add(cur);
                }
                else {
                    if (cur.treeNode.left != null) {
                        var left = new CustomTreeNode(cur.treeNode.left, cur);
                        cur.left = left;
                        queue.add(left);
                    }
                    if (cur.treeNode.right != null) {
                        var right = new CustomTreeNode(cur.treeNode.right, cur);
                        cur.right = right;
                        queue.add(right);
                    }
                }
            }
        }

        while (!leafQueue.isEmpty()) {
            var current = leafQueue.poll();
            current.visited = true;

            // try to take both
            if (current.left != null && current.right != null && current.left.visited && current.right.visited) {
                var currentMaxPathSum = current.treeNode.val + current.left.maxPathSum + current.right.maxPathSum;
                maxValue = Math.max(maxValue, currentMaxPathSum);
            }

            // try to take on of the children
            var maxGain = 0;
            if (current.left != null && current.left.visited) {
                maxGain = Math.max(maxGain, current.left.maxPathSum);
            }
            if (current.right != null && current.right.visited) {
                maxGain = Math.max(maxGain, current.right.maxPathSum);
            }
            current.maxPathSum = current.maxPathSum + maxGain;

            // try to add parent to queue
            var parent = current.parent;
            if (parent != null && (parent.left == null || parent.left.visited) && (parent.right == null || parent.right.visited)) {
                leafQueue.add(current.parent);
            }

            maxValue = Math.max(maxValue, current.maxPathSum);
        }


        return maxValue;
    }
}