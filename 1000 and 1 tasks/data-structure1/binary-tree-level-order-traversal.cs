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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        if (root == null) {
            return new List<IList<int>>();
        }

        var expectedChildNodes = 1;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var res = new List<IList<int>>();

        while (queue.Any()) {
            var levelList = new List<int>();
            var newExpectedChildNodes = 0;
            for (int i = 0; i < expectedChildNodes; i++) {
                var cur = queue.Dequeue();
                levelList.Add(cur.val);

                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                    newExpectedChildNodes++;
                }
                
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                    newExpectedChildNodes++;
                }
            }

            expectedChildNodes = newExpectedChildNodes;
            res.Add(levelList as IList<int>);
        }

        return res;
        
    }
}