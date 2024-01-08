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
    // calc left boundary
    // calc right boundary
    // leaves = post DFS

    private List<int> LeftBoundary = new ();
    private List<int> RightBoundary = new ();
    private List<int> Leaves = new ();

    private void FindLeftBoundary(TreeNode root) {
        if (root.left != null) {
            FindLeftBoundary(root.left);
        }
        else if (root.right != null) {
            FindLeftBoundary(root.right);
        }

        if (root.left != null || root.right != null) {
            LeftBoundary.Add(root.val);
        }
    }

    private void FindRightBoundary(TreeNode root) {
        if (root.right != null) {
            FindRightBoundary(root.right);
        }
        else if (root.left != null) {
            FindRightBoundary(root.left);
        }

        if (root.left != null || root.right != null) {
            RightBoundary.Add(root.val);
        }
    }

    public void FindLeaves(TreeNode root) {
        if (root.left != null) {
            FindLeaves(root.left);
        }
        if (root.right != null) {
            FindLeaves(root.right);
        }
        if (root.left == null && root.right == null) {
            Leaves.Add(root.val);
        }
    }

    public IList<int> BoundaryOfBinaryTree(TreeNode root) {
        if (root.left == null && root.right == null) {
            return new List<int>() {root.val};
        }

        if (root?.left != null) {
            FindLeftBoundary(root.left);
        }
        if (root.right != null) {
            FindRightBoundary(root.right);
        }
        if (root != null) {
            FindLeaves(root);
        }

        var result = new List<int>();
        if (root != null) {
            result.Add(root.val);
        }
        for (int i = LeftBoundary.Count() - 1; i >= 0; i-- ) {
            result.Add(LeftBoundary[i]);
        }
        foreach (var x in Leaves) {
            result.Add(x);
        }
        foreach (var x in RightBoundary) {
            result.Add(x);
        }


        return result;
    }
}