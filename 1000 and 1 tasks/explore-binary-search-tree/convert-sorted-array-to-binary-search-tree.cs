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
public class Solution {

    private int[] _nums;

    private TreeNode Build(int l, int r) {
        if (l > r) {
            return null;
        }
        if (l == r) {
            return new TreeNode(_nums[l]);
        }

        var m = l + (r-l)/2;

        var node = new TreeNode(_nums[m]);
        node.left = Build(l, m -1);
        node.right = Build(m+1, r);

        return node;
    }

    // функция с вершиной и отрезком в аргументе
    public TreeNode SortedArrayToBST(int[] nums) {
        _nums = nums;

        return Build(0, nums.Length - 1);
    }
}