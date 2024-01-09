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
    // left -- right ++
    // BFS with score
    // no gaps in lines


    // решил сам, но смотрел сюда: https://leetcode.com/problems/find-leaves-of-binary-tree/?envType=study-plan-v2&envId=premium-algo-100

    public IList<IList<int>> VerticalOrder(TreeNode root) {
        var lefts = new List<IList<int>>();
        // easier indexing
        var rights = new List<IList<int>>() {null};

        var queue = new Queue<(TreeNode node, int score)>();
        if (root != null) {
            queue.Enqueue((root, 0));
        }

        while (queue.Any()) {
            var (cur, score) = queue.Dequeue();
            // left
            if (score <= 0) {
                var abs = Math.Abs(score);
                if (abs == lefts.Count()) {
                    lefts.Add(new List<int>());
                }
                lefts[abs].Add(cur.val);
            }
            // right
            else {
                if (score == rights.Count()) {
                    rights.Add(new List<int>());
                }
                rights[score].Add(cur.val);
            }

            if (cur.left != null) {
                queue.Enqueue((cur.left , score - 1));
            }
            if (cur.right != null) {
                queue.Enqueue((cur.right , score + 1));
            }
        }

        var result = new List<IList<int>>();
        for (int i = lefts.Count()-1; i >= 0; i--) {
            result.Add(lefts[i]);
        }

        for (int i = 1; i < rights.Count(); i++) {
            result.Add(rights[i]);
        }

        return result;
    }
}