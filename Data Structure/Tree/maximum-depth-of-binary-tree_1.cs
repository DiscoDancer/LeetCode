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

public class TreeNodeLeveled {
    public TreeNode node;
    public int level;
    public TreeNodeLeveled(TreeNode n, int l) {
        node = n;
        level = l;
    }
}

public class Solution {
    
//     public int _max = 0;
    
//     public void F(TreeNode root, int level) {
//         _max = Math.Max(level, _max);
        
//         if (root != null) {
//             if (root.left != null) {
//                 F(root.left, level + 1);
//             }
//             if (root.right != null) {
//                 F(root.right, level + 1);
//             }
//         }
//     }
    
    public int MaxDepth(TreeNode root) {
        
        if (root == null) {
            return 0;
        }
        
        var queue = new Queue<TreeNodeLeveled>();
        queue.Enqueue(new TreeNodeLeveled(root, 1));
        
        int max = 0;
        
        while (queue.Any()) {
            var cur = queue.Dequeue();
            max = Math.Max(max, cur.level);
            
            if (cur.node.left != null) {
                queue.Enqueue(new TreeNodeLeveled(cur.node.left, cur.level + 1 ) );
            }
            if (cur.node.right != null) {
                queue.Enqueue(new TreeNodeLeveled(cur.node.right, cur.level + 1 ) );
            }
        }
        
        return max;
        
    }
}