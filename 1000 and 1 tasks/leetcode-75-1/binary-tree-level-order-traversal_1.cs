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

        var queue = new Queue<(TreeNode node, int level)>();
        queue.Enqueue((root, 0));

        var previousLevel = -1;
        var currentList = new List<int>();
        IList<IList<int>> res = new List<IList<int>>();

        while (queue.Any()) {
            var current = queue.Dequeue();
            if (current.level != previousLevel) {
                if (currentList.Any()) {
                    res.Add(currentList as IList<int>);
                }
                currentList = new List<int>();
                previousLevel = current.level;
            }
            currentList.Add(current.node.val);

            if (current.node.left != null) {
                queue.Enqueue((current.node.left, current.level + 1));
            }
            if (current.node.right != null) {
                queue.Enqueue((current.node.right, current.level + 1));
            }
        }

        if (currentList.Any()) {
            res.Add(currentList as IList<int>);
        }
        
        return res as IList<IList<int>>;
    }
}