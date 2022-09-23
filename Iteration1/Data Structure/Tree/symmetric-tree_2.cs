/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * public int val;
 * public TreeNode left;
 * public TreeNode right;
 * public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 * this.val = val;
 * this.left = left;
 * this.right = right;
 * }
 * }
 */
public class Solution {
    
    public void DFS(TreeNode root) {
        if (root.left != null) {
            DFS(root.left);
        }
        if (root.right != null) {
            DFS(root.right);
        }
    }
    
    // DFS рекурсией и списочек(массив)
    // DFS итеративно на 2 стека или даже на 1
    // BFS проверить симметричность уровня
    
    public bool IsSymmetric(TreeNode root) {
        if (root == null) {
            return false;
        }
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(root);
        
        while (queue.Any()) {
            var c1 = queue.Dequeue();
            var c2 = queue.Dequeue();
            
            if (c1 == null && c2 == null) {
                continue;
            }
            if (c1 == null || c2 == null) {
                return false;
            }
            
            if (c1.val != c2.val) {
                return false;
            }
            
            queue.Enqueue(c1.left);
            queue.Enqueue(c2.right);
            queue.Enqueue(c1.right);
            queue.Enqueue(c2.left);
        }
        
        return true;
    }
}