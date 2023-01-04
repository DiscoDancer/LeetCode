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
    // cur2 -> cur1
public  TreeNode? MergeTrees(TreeNode? root1, TreeNode? root2) {
        if (root1 == null) {
            return root2;
        }

        var queue = new Queue<(TreeNode? n1, TreeNode? n2)>();
        queue.Enqueue((root1, root2));

        while (queue.Any()) {
            var (cur1, cur2) = queue.Dequeue();
            if (cur2 == null) {
                continue;
            }

            cur1.val += cur2.val;

            if (cur1.left == null) {
                cur1.left = cur2.left;
            }
            else {
                queue.Enqueue((cur1.left, cur2.left));
            }

            if (cur1.right == null) {
                cur1.right = cur2.right;
            }
            else {
                queue.Enqueue((cur1.right, cur2.right));
            }

        }

        return root1;
    }
}