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
    // надо идти от листиков (или от уровней) и в вершинах писать число и так в корень придет ответ
    // но тогда надо дерево разобрать (табличка, кто чей родитель)
    public int LongestConsecutive(TreeNode root) {
        var parentTable = new Dictionary<TreeNode, TreeNode>();
        var resultTable = new Dictionary<TreeNode, int>();

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
                resultTable[cur] = 1;
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
                max = Math.Max(max, resultTable[node]);
                if (parentTable[node] != null) {
                    var parent = parentTable[node];
                    if (parent.val + 1 == node.val) {
                        resultTable[parent] = Math.Max(
                            resultTable[parent],
                            resultTable[node] + 1
                        );
                    }
                }
            }
        }

        return max;
    }
}