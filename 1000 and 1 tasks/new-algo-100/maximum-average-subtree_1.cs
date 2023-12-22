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
    // у меня нет четкого алгоритма

    // идем снизу вверх. Если дети увеличиваю мое среднее, берем их, иначе нет


    /*
    A subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. The tree tree could also be considered as a subtree of itself.
    */


    public double MaximumAverageSubtree(TreeNode root) {
        var sumTable = new Dictionary<TreeNode, double>();
        var countTable = new Dictionary<TreeNode, int>();

        // обход по уровням, уровни нужно сохранить
        var queue = new Queue<TreeNode>();
        var levels = new List<List<TreeNode>>();
        queue.Enqueue(root);

        while (queue.Any()) {
            var size = queue.Count();
            var list = new List<TreeNode>();
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                if (cur.left == null && cur.right == null) {
                    sumTable[cur] = cur.val;
                    countTable[cur] = 1;
                }
                list.Add(cur);
                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                }
            }
            levels.Add(list);
        }

        double max = 0;
        // идем снизу вверх. Если дети увеличиваю мое среднее, берем их, иначе нет
        var levelsCount = levels.Count();
        for (int i = levelsCount - 1; i >= 0; i--) {
            foreach (var node in levels[i]) {
                double sum = node.val;
                int count = 1;
                if (node.left != null) {
                    sum += sumTable[node.left];
                    count += countTable[node.left];
                }
                if (node.right != null) {
                    sum += sumTable[node.right];
                    count += countTable[node.right];
                }
                sumTable[node] = sum;
                countTable[node] = count;
                max = Math.Max(max, sumTable[node] / countTable[node]);
            }
        }

        return max;
    }
}