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
    private List<int> arr = new ();

    private void Inorder(TreeNode root) {
        if (root.left != null) {
            Inorder(root.left);
        }
        arr.Add(root.val);
        if (root.right != null) {
            Inorder(root.right);
        }
    }

    public IList<int> ClosestKValues(TreeNode root, double target, int k) {
        Inorder(root);

        var start = 0;
        var minDiff = double.MaxValue;
        
        for (int i = 0; i < arr.Count(); i++) {
            if (Math.Abs(arr[i] - target) < minDiff) {
                minDiff = Math.Abs(arr[i] - target);
                start = i;
            }
        }

        var left = start;
        var right = start + 1;

        while (right - left - 1 < k) {
            // Be careful to not go out of bounds
            if (left < 0) {
                right += 1;
                continue;
            }
            if (right == arr.Count() ||  Math.Abs(arr[left] - target) <= Math.Abs(arr[right] - target)) {
                left -= 1;
            }
            else {
                right += 1;
            }
        }

        return arr.Skip(left + 1).Take(right - 1 - left).ToList();
    
    }
}