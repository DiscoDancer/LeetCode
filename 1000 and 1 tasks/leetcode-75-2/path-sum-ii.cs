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
    // строки мб быстрее копируются
    // backtracking
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        var queue = new Queue<(TreeNode node, List<int> list)>();

        if (root != null) {
            queue.Enqueue((root, new List<int>()));
        }

        var allPaths = new List<IList<int>>();

        while (queue.Any()) {
            var (node, list) = queue.Dequeue();

            list.Add(node.val);
            if (node.left == null && node.right == null) {
                if (list.Sum() == targetSum) {
                    allPaths.Add(list.ToList());
                }
            }

            if (node.right != null) {
                queue.Enqueue((node.right, list.ToList()));
            }
            if (node.left != null) {
                queue.Enqueue((node.left, list.ToList()));
            }
        }

        return allPaths;
    }
}