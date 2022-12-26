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

    private List<int> _list = new List<int>();

    private void InOrder(TreeNode root) {
        if (root.left != null) {
            InOrder(root.left);
        }
        _list.Add(root.val);
        if (root.right != null) {
            InOrder(root.right);
        }
    }

    public bool FindTarget(TreeNode root, int k) {
        if (root == null) {
            return false;
        }

        InOrder(root);
        var arr = _list.ToArray();

        var l = 0;
        var r = arr.Length - 1;

        while (l < r) {
            var sum = arr[l] + arr[r];
            if (sum == k) {
                return true;
            }
            else if (sum < k) {
                l++;
            }
            else {
                r--;
            }
        }

        return false;
    }
}