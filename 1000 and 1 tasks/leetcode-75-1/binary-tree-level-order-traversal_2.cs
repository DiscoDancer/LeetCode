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

// мб можно привести к массиву, и там ловко посчитать 
// за уровнем можно следить через tuple с уровнем
public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        if (root == null) {
            IList<IList<int>> badRes = new List<IList<int>>();
            return badRes;
        }

        IList<IList<int>> res = new List<IList<int>>();

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var expectingOnCurrentLevel = 1;
        while (queue.Any()) {
            var currentList = new List<int>();
            var expectingOnNextLevel = 0;
            for (int i = 0; i < expectingOnCurrentLevel; i++) {
                var current = queue.Dequeue();
                currentList.Add(current.val);

                if (current.left != null) {
                    queue.Enqueue(current.left);
                    expectingOnNextLevel++;
                }
                if (current.right != null) {
                    queue.Enqueue(current.right);
                    expectingOnNextLevel++;
                }
            }

            res.Add(currentList as IList<int>);

            expectingOnCurrentLevel = expectingOnNextLevel;
        }

        return res as IList<IList<int>>;
    }
}