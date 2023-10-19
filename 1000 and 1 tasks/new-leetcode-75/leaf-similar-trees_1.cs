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
    // алгоритм по уровням не сработает
    // post order

    private List<int> list1 = new ();
    private bool result = true;

    private void PostOrder1(TreeNode root, List<int> list) {
        if (root.left != null) {
            PostOrder1(root.left, list);
        }
        if (root.right != null) {
            PostOrder1(root.right, list);
        }
        if (root.left == null && root.right == null) {
            list.Add(root.val);
        }
    }

    private void PostOrder2(TreeNode root, List<int> list) {
        if (!result) {
            return;
        }

        if (root.left != null) {
            PostOrder2(root.left, list);
        }
        if (root.right != null) {
            PostOrder2(root.right, list);
        }
        if (root.left == null && root.right == null) {
            if (!list.Any() || root.val != list[0]) {
                result = false;
                return;
            }
            else {
                list.RemoveAt(0);
            }
        }
    }


    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        PostOrder1(root1, list1);
        PostOrder2(root2, list1);

        return !list1.Any() && result;
    }
}