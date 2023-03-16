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
    // tree level
    public IList<int> RightSideView(TreeNode root) {
        var expectedChildrenCount = root == null ? 0 : 1;
        var queue = new Queue<TreeNode>();
        if (root != null) {
            queue.Enqueue(root);
        }
        var result = new List<int>();

        while (queue.Any()) {
            
            var countChildren = 0;
            for (int i = 0; i < expectedChildrenCount; i++) {
                var cur = queue.Dequeue();
                if (cur.left != null) {
                    countChildren++;
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null) {
                    countChildren++;
                    queue.Enqueue(cur.right);
                }
                if (i == expectedChildrenCount - 1) { // last
                    result.Add(cur.val);
                }
            }

            expectedChildrenCount = countChildren;
        }

        return result;
    }
}