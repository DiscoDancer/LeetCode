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
    // вариант: деревья как массив, merge, обратно
    // рекурсивно
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
        if (root1 == null && root2 == null) {
            return null;
        }
        if (root1 == null) {
            return root2;
        }
        if (root2 == null) {
            return root1;
        }

        var newNode = new TreeNode(root1.val + root2.val);
        newNode.left = MergeTrees(root1.left, root2.left);
        newNode.right = MergeTrees(root1.right, root2.right);

        return newNode;
    }
}