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

    private int _max = 1;

    public int MaxDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }

        var expectedChildrenCount = 1;
        var queue = new Queue<TreeNode>();
        int levels = 0;
        queue.Enqueue(root);

        while (queue.Any()) {
            var newExpectedChildrenCount = 0;
            for (int i = 0; i < expectedChildrenCount; i++) {
                var cur = queue.Dequeue();
                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                    newExpectedChildrenCount++;
                }
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                    newExpectedChildrenCount++;
                }
            }
            expectedChildrenCount = newExpectedChildrenCount;
            levels++;
        }

        return levels;
        
    }
}