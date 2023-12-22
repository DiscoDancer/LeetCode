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
    public int LongestConsecutive(TreeNode root) {
        var parentTable = new Dictionary<TreeNode, TreeNode>();
        var incChildrenTable = new Dictionary<TreeNode, int>();
        var decChildrenTable = new Dictionary<TreeNode, int>();

        // обход по уровням, уровни нужно сохранить
        var queue = new Queue<TreeNode>();
        var levels = new List<List<TreeNode>>();
        queue.Enqueue(root);
        parentTable[root] = null;

        while (queue.Any()) {
            var size = queue.Count();
            var list = new List<TreeNode>();
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                incChildrenTable[cur] = 0;
                decChildrenTable[cur] = 0;
                list.Add(cur);
                if (cur.left != null) {
                    parentTable[cur.left] = cur;
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null) {
                    parentTable[cur.right] = cur;
                    queue.Enqueue(cur.right);
                }
            }
            levels.Add(list);
        }

        var max = 0;

        var levelsCount = levels.Count();
        for (int i = levelsCount - 1; i >= 0; i--) {
            foreach (var node in levels[i]) {
                max = Math.Max(max, incChildrenTable[node] + 1 + decChildrenTable[node]);
                if (parentTable[node] != null) {
                    var parent = parentTable[node];
                    if (parent.val + 1 == node.val) {
                        incChildrenTable[parent] = Math.Max(incChildrenTable[parent], incChildrenTable[node] + 1);
                    }
                    if (parent.val - 1 == node.val) {
                        decChildrenTable[parent] = Math.Max(decChildrenTable[parent], decChildrenTable[node] + 1);
                    }
                }
            }
        }

        return max;
    }
}