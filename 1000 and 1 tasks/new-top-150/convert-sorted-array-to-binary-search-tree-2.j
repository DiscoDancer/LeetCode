import java.util.LinkedList;
import java.util.Queue;
import java.util.Stack;

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

    private TreeNode F(int l, int r) {
        if (l > r) {
            return null;
        }
        if (l == r) {
            return new TreeNode(nums[l]);
        }

        var m = l + (r - l) / 2;
        var node = new TreeNode(nums[m]);
        node.left = F(l, m - 1);
        node.right = F(m + 1, r);
        
        return node;
    }

    public TreeNode sortedArrayToBST(int[] nums) {
        this.nums = nums;
        var root = F(0, nums.length - 1);
        return root;
    }
}