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
    // за квадрат изи
    // звучит как DP

    public const int PARENT_LEFT = 1;
    public const int PARENT_RIGHT = 2;

    private int _max = 0;
    private Dictionary<(TreeNode node, int parentState), int> _cache = new ();

    private void Traverse(TreeNode node) {
        if (node.left != null) {
            Traverse(node.left);
        }
        if (node.right != null) {
            Traverse(node.right);
        }

        _max = Math.Max(_max, Proccess(node, 0));
    }

    private int Proccess(TreeNode node, int parentState) {
        if (_cache.ContainsKey((node,parentState))) {
            return _cache[(node,parentState )];
        }
        var left = 0;
        var right = 0;
        if (node.left != null && parentState != PARENT_LEFT ) {
            left = 1 + Proccess(node.left, PARENT_LEFT);
        }
        if (node.right != null && parentState != PARENT_RIGHT) {
            right = 1 + Proccess(node.right, PARENT_RIGHT);
        }

        _cache[(node,parentState )] = Math.Max(left, right);
        return _cache[(node,parentState )];
    }

    public int LongestZigZag(TreeNode root) {
        Traverse(root);

        return _max;
    }
}