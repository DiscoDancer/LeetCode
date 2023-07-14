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

// editorial
public class Solution {
    private IList<TreeNode> F(int start, int end) {
        var result = new List<TreeNode>();
        if (start > end) {
            result.Add(null);
            return result;
        }

        for (int i = start; i <= end; i++) {
            var leftSubTrees = F(start, i - 1);
            var rightSubTrees = F(i+1, end);

            foreach (var left in leftSubTrees) {
                foreach (var right in rightSubTrees) {
                    var root = new TreeNode(i, left, right);
                    result.Add(root);
                }
            }
        }

        return result;
    }

    public IList<TreeNode> GenerateTrees(int n) {
        return F(1, n);
    }
}