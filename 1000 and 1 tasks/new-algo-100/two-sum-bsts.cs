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
    // arr1 arr2 sorted, then 2 pointers O(n) / O(n)
    // naive search O(n*logn) / O(1)
    // inorder iterator -> O(n) * 2 -> O(n)*1

    private void Convert(List<int> list, TreeNode root) {
        if (root.left != null) {
            Convert(list, root.left);
        }

        list.Add(root.val);

        if (root.right != null) {
            Convert(list, root.right);
        }
    }

    public bool TwoSumBSTs(TreeNode root1, TreeNode root2, int target) {
        var list1 = new List<int>();
        var list2 = new List<int>();
        Convert(list1, root1 );
        Convert(list2, root2 );

        var p = 0;
        var q = list2.Count()-1;

        while (p < list1.Count() && q >= 0) {
            var sum = list1[p] + list2[q];
            if (sum == target) {
                return true;
            }
            else if (sum < target) {
                p++;
            }
            else {
                q--;
            }
        }

        return false;
    }
}