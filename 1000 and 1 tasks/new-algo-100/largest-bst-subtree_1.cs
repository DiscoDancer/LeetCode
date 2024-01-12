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
    // leaf is subtree
    // can find count of children for each node = O(n)/O(n)
    // bottom to up
    public int LargestBSTSubtree(TreeNode root) {
        if (root == null) {
            return 0;
        }

        var levels = new List<List<TreeNode>>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var result = 0;

        var scoreTable = new Dictionary<TreeNode, int>();
        var minTable = new Dictionary<TreeNode, int>();
        var maxTable = new Dictionary<TreeNode, int>();

        while (queue.Any()) {
            var size = queue.Count();
            var level = new List<TreeNode>();

            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                scoreTable[cur] = 0;
                minTable[cur] = cur.val;
                maxTable[cur] = cur.val;
                level.Add(cur);
                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                }
            }
            levels.Add(level);
        }

        for (int i = levels.Count() - 1; i >= 0; i--) {
            var level = levels[i];
            foreach (var node in level) {
                var isLeftOk = node.left == null || (scoreTable[node.left] != 0 && node.left.val < node.val && maxTable[node.left] < node.val);
                var isRightOk = node.right == null || (scoreTable[node.right] != 0 && node.right.val > node.val && minTable[node.right] > node.val);
                if (isLeftOk && isRightOk) {
                    scoreTable[node] = 1 + (node.left == null ? 0 : scoreTable[node.left]) +
                        (node.right == null ? 0 : scoreTable[node.right]);
                    if (node.left != null) {
                        minTable[node] = Math.Min(minTable[node], minTable[node.left]);
                    }
                    if (node.right != null) {
                        maxTable[node] = Math.Max(maxTable[node], maxTable[node.right]);
                    }
                    result = Math.Max(result, scoreTable[node]);
                }
            }
        }

        return result;
    }
}