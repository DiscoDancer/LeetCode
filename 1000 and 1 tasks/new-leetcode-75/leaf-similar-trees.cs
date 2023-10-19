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
    private List<int> list2 = new ();

    private void PostOrder(TreeNode root, List<int> list) {
        if (root.left != null) {
            PostOrder(root.left, list);
        }
        if (root.right != null) {
            PostOrder(root.right, list);
        }
        if (root.left == null && root.right == null) {
            list.Add(root.val);
        }
    }


    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        PostOrder(root1, list1);
        PostOrder(root2, list2);

        return Enumerable.SequenceEqual(list1, list2);
    }
}