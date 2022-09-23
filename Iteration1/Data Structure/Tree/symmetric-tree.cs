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
    public bool IsSymmetric(TreeNode root) {
        if (root == null) {
            return false;
        }

        var queue = new Queue <TreeNode>();
        queue.Enqueue(root);

        while (queue.Any()) {
            var size = queue.Count();
            
            var list = new List<int?>();

            // уровненый список с null, идем с 2х сторон
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                
                list.Add(cur.left == null ? 1000 : cur.left.val);
                list.Add(cur.right == null ? 1000 : cur.right.val);

                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                }
            }
            
            var arr = list.ToArray();
            var L = 0; 
            var R = arr.Length - 1;
            
            while (L < R) {
                if (arr[L] != arr[R]) {
                    return false;
                }
                L++;
                R--;
            }
        }

        return true;
    }
}