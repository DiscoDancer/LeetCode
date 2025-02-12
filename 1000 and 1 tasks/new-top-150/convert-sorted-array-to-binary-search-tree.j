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

    private int[] nums;
    private int numsIndex;

    private void Inorder(TreeNode node) {
        if (node == null) {
            return;
        }
        Inorder(node.left);
        node.val = nums[numsIndex++];
        Inorder(node.right);
    }

    public TreeNode sortedArrayToBST(int[] nums) {
        var n = nums.length;

        Queue<TreeNode> queue = new LinkedList<>();
        queue.add(new TreeNode(0, null, null));
        var root = queue.peek();
        var totalSize = 1;

        while (!queue.isEmpty() && totalSize < n) {
            var levelSize = queue.size();
            for (int i = 0; i < levelSize && totalSize < n; i++) {
                var cur = queue.poll();
                if (totalSize < n) {
                    cur.left = new TreeNode(0, null, null);
                    queue.add(cur.left);
                    totalSize++;
                }
                if (totalSize < n) {
                    cur.right = new TreeNode(0, null, null);
                    queue.add(cur.right);
                    totalSize++;
                }
            }
        }
        
        this.nums = nums;
        this.numsIndex = 0;

        Inorder(root);

        return root;
    }
}