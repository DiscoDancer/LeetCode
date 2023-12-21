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
    // мб если бы я пошел от родителя искать уменьшение, было бы
    public int LongestConsecutive(TreeNode root) {
        var queue = new Queue<(TreeNode node, int score)>();
        queue.Enqueue((root, 1));
        var max = 0;

        while (queue.Any()) {
            var size = queue.Count();
            for (int i = 0; i < size; i++) {
                var (node, score) = queue.Dequeue();
                max = Math.Max(max, score);

                if (node.left != null) {
                    var leftScore = node.left.val - 1 == node.val ? score + 1 : 1;
                    queue.Enqueue((node.left, leftScore));
                }
                if (node.right != null) {
                    var rightScore = node.right.val - 1 == node.val ? score + 1 : 1;
                    queue.Enqueue((node.right, rightScore));
                }
            }
        }

        return max;
    }
}