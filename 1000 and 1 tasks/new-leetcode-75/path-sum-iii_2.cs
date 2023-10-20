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
    private int _count = 0;
    private long _targetSum;
    private Dictionary<long, int> _dictionary = new ();

    private void TopDown(TreeNode node, long currSum) {
        if (node == null) {
            return;
        }

        currSum += node.val;

        if (currSum == _targetSum) {
            _count++;
        }

        if (_dictionary.ContainsKey(currSum - _targetSum)) {
             _count += _dictionary[currSum - _targetSum];
        }

        if (_dictionary.ContainsKey(currSum)) {
            _dictionary[currSum]++;
        } else {
            _dictionary[currSum] = 1;
        }

        TopDown(node.left, currSum);
        TopDown(node.right, currSum);

        _dictionary[currSum]--;
    }

    // editorial
    public int PathSum(TreeNode root, int targetSum) {
        _targetSum = targetSum;
        TopDown(root, 0L);
        return _count;
    }
}