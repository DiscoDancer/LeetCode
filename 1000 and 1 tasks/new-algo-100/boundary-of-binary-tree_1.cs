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
        var p = root;
        while (p != null) {
            if (p.left != null || p.right != null) {
                LeftBoundary.Add(p.val);
            }
            if (p.left != null) {
                p = p.left;
            }
            else {
                p = p.right;
            }
        }
    }

    private void FindRightBoundary(TreeNode root) {
        var p = root;
        while (p != null) {
            if (p.left != null || p.right != null) {
                RightBoundary.Insert(0, p.val);
            }
            if (p.right != null) {
                p = p.right;
            }
            else {
                p = p.left;
            }
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
        foreach (var x in LeftBoundary) {
            result.Add(x);
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