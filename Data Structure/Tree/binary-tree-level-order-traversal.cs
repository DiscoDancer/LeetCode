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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        if (root == null) {
            return new List<IList<int>>() {};
        }
        
        var res = new List<IList<int>>();
        
        while (queue.Any()) {
            var size = queue.Count();
            
            var l = new List<int>();
            
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                l.Add(cur.val);
                
                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                }
            }
            
            res.Add(l);
        }
        
        return res;
    }
}