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
    public bool FindTarget(TreeNode root, int k) {
        if (root == null || root.left == null && root.right == null) {
            return false;
        }
        
        var dictionary = new Dictionary<int, bool>();
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Any()) {
            var cur = queue.Dequeue();
            
            dictionary[cur.val] = true;
            
            var x = k - cur.val;
            if (cur.val != x && dictionary.ContainsKey(x)) {
                return true;
            }
            
            if (cur.left != null) {
                queue.Enqueue(cur.left);
            }
            if (cur.right != null) {
                queue.Enqueue(cur.right);
            }
        }
        
        return false;
        
        
        // tree -> list (x -> k - x)
        // for n in list BST tree
        // список мы можем не хранить, а сразу искать
    }
}