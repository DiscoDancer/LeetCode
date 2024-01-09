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
    // table chilren count node -> 0..2
    // table chilren-parent node -> node

    // traverse -> queue of leaves + fill tables

    // while queue any 
        // size = queue.Count()
        // for i = 0 i < size

    // destoy tree -> no count table 

    public IList<IList<int>> FindLeaves(TreeNode root) {
        var parentTable = new Dictionary<TreeNode, TreeNode>();
        var leavesQueue = new Queue<TreeNode>();

        var queue = new Queue<(TreeNode n, TreeNode p)>();
        if (root != null) {
            queue.Enqueue((root, null));
        }

        while (queue.Any()) {
            var (cur, parent) = queue.Dequeue();
            var childCount = 0;

            if (cur.left != null) {
                queue.Enqueue((cur.left, cur));
            }
            if (cur.right != null) {
                queue.Enqueue((cur.right, cur));
            }

            parentTable[cur] = parent;
            if (cur.left == null && cur.right == null) {
                leavesQueue.Enqueue(cur);
            }
        }

        var result = new List<IList<int>>();

        while (leavesQueue.Any()) {
            var size = leavesQueue.Count();
            var list = new List<int>();
            for (int i = 0; i < size; i++) {
                var leaf = leavesQueue.Dequeue();
                list.Add(leaf.val);

                var parent = parentTable[leaf];
                if (parent != null) {
                    if (parent.left == leaf) {
                        parent.left = null;
                    }
                    if (parent.right == leaf) {
                        parent.right = null;
                    }
                    if (parent.left == null && parent.right == null) {
                        leavesQueue.Enqueue(parent);
                    }
                }
            }
            result.Add(list);
        }

        return result;
    }
}