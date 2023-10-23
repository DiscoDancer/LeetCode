/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    // найти 2 пути и обойти списки
    // хранить parent
    // DFS BFS

    // можно в int
    // backtracking
    private Dictionary<TreeNode, TreeNode> _parentByNode = new ();

    private void DFS(TreeNode root, TreeNode parent) {
        _parentByNode[root] = parent;

        if (root.left != null) {
            DFS(root.left, root);
        }
        if (root.right != null) {
            DFS(root.right, root);
        }
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        DFS(root, null);

        var listP = new List<TreeNode>();
        var listQ = new List<TreeNode>();

        var cur = p;
        while (cur != null) {
            listP.Insert(0, cur);
            var parent = _parentByNode[cur];
            cur = parent;
        }

        cur = q;
        while (cur != null) {
            listQ.Insert(0, cur);
            var parent = _parentByNode[cur];
            cur = parent;
        }

        var curIndex = 0;
        TreeNode result = null;
        while (curIndex < Math.Min(listP.Count(), listQ.Count()) && listP[curIndex] == listQ[curIndex]) {
            result = listP[curIndex];
            curIndex++;
        }

        return result;
    }
}