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

    private int _targetSum;
    private List<IList<int>> _result = new ();

    private void TopDown(TreeNode root, List<int> list) {
        if (root.left == null && root.right == null && list.Sum() == _targetSum) {
            _result.Add(list.ToList());
        }

        if (root.left != null) {
            list.Add(root.left.val);
            TopDown(root.left, list);
            list.RemoveAt(list.Count() - 1);
        }
        if (root.right != null) {
            list.Add(root.right.val);
            TopDown(root.right, list);
            list.RemoveAt(list.Count() - 1);
        }
    }

    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        _targetSum = targetSum;
        if (root != null) {
            var list = new List<int> () {root.val};
            TopDown(root, list);
        }

        return _result;
    }
}