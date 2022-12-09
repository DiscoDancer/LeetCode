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

        var preRes = new List<(int value, int level)>();
        while (queue.Any()) {
            var current = queue.Dequeue();
            preRes.Add((current.node.val, current.level));
            if (current.node.left != null) {
                queue.Enqueue((current.node.left, current.level + 1));
            }
            if (current.node.right != null) {
                queue.Enqueue((current.node.right, current.level + 1));
            }
        }

        IList<IList<int>> res = new List<IList<int>>();
        var dic = new Dictionary<int, List<int>>();

        var levels = 0;
        foreach(var entry in preRes) {
            if (dic.ContainsKey(entry.level)) {
                dic[entry.level].Add(entry.value);
            }
            else {
                levels++;
                dic[entry.level] = new List<int>() {entry.value};
            }
        }

        for (int i = 0; i < levels; i++) {
            res.Add(dic[i] as IList<int>);
        }

        return res as IList<IList<int>>;
    }
}