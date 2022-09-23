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
    
    public void FillPath(TreeNode root, TreeNode destination, List<TreeNode> path) {
        var cur = root;
        path.Add(cur);
        
        while (cur != destination) {
            if (destination.val < cur.val) {
                cur = cur.left;
            }
            else {
                cur = cur.right;
            } 
            path.Add(cur);
        }
        
    }
    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var pathP = new List<TreeNode>();
        var pathQ = new List<TreeNode>();
        
        FillPath(root, p, pathP);
        FillPath(root, q, pathQ);
        
        return pathP.Intersect(pathQ).Last();
        
        // ищем 2 и получаем список (путь)
        // ищем 8 и получаем список (путь)
        // сопоставляет списочки max от intersect или 2 pointers
    }
}