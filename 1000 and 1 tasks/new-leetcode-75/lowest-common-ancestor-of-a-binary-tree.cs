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
    // 2 списка и пройтись по ним
    // мб какой-то обход даст результат
    // по уровням можно ходить (сложна)

    private List<TreeNode> _path1;
    private List<TreeNode> _path2;

    private void Find1(TreeNode root, TreeNode target, List<TreeNode> curPath) {
        if (root == target) {
            _path1 = curPath.ToList();
            return;
        }

        if (root.left != null) {
            curPath.Add(root.left);
            Find1(root.left, target, curPath);
            // в каком месте он будет?
            curPath.Remove(root.left);
        }
        if (root.right != null) {
            curPath.Add(root.right);
            Find1(root.right, target, curPath);
            // в каком месте он будет?
            curPath.Remove(root.right);
        }
    }

    private void Find2(TreeNode root, TreeNode target, List<TreeNode> curPath) {
        if (root == target) {
            _path2 = curPath.ToList();
            return;
        }

        if (root.left != null) {
            curPath.Add(root.left);
            Find2(root.left, target, curPath);
            // в каком месте он будет?
            curPath.Remove(root.left);
        }
        if (root.right != null) {
            curPath.Add(root.right);
            Find2(root.right, target, curPath);
            // в каком месте он будет?
            curPath.Remove(root.right);
        }
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        // можно и за один обход найти
        Find1(root, p, new List<TreeNode>() {root});
        Find2(root, q, new List<TreeNode>() {root});

        var i = 0;
        var j = 0;

        while (i < _path1.Count() && j < _path2.Count() && _path1[i] == _path2[j]) {
            i++;
            j++;
        }

        return _path1[i-1];
    }
}