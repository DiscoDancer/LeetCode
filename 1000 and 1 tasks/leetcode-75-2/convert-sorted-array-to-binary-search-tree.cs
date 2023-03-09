/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/submissions/
public class Solution {
    private int[] _nums;

    public TreeNode Insert(int left, int right) {
        if (left > right) {
            return null;
        }

        var middle = (left + right) / 2;
        var root = new TreeNode(_nums[middle]);
        root.left = Insert(left, middle - 1);
        root.right = Insert(middle + 1, right);
        return root;
    }

    public TreeNode SortedArrayToBST(int[] nums) {
        _nums = nums;

        return Insert(0, _nums.Length - 1);
    }
}