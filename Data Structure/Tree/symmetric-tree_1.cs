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
    
    public bool IsSymmetric(TreeNode root) {
        if (root == null) {
            return false;
        }
        
        var stack = new Stack<TreeNode>();
        var stack2 = new Stack<TreeNode>();
        stack.Push(root);
        stack2.Push(root);
        
        while (stack.Any() && stack2.Any()) {
            var cur = stack.Pop();
            var cur2 = stack2.Pop();
            
            if (cur == null && cur2 != null || cur != null && cur2 == null || (cur != null && cur2 != null && cur.val != cur2.val)) {
                return false;
            }
            
            if (cur != null) {
                stack.Push(cur.right);
                stack.Push(cur.left);
            }
            
            if (cur2 != null) {
                stack2.Push(cur2.left);
                stack2.Push(cur2.right);
            }
        }
        
        return !stack.Any() && !stack2.Any();

//         var queue = new Queue <TreeNode>();
//         queue.Enqueue(root);

//         while (queue.Any()) {
//             var size = queue.Count();
            
//             var list = new List<int?>();

//             // уровненый список с null, идем с 2х сторон
//             for (int i = 0; i < size; i++) {
//                 var cur = queue.Dequeue();
                
//                 list.Add(cur.left == null ? 1000 : cur.left.val);
//                 list.Add(cur.right == null ? 1000 : cur.right.val);

//                 if (cur.left != null) {
//                     queue.Enqueue(cur.left);
//                 }
//                 if (cur.right != null) {
//                     queue.Enqueue(cur.right);
//                 }
//             }
            
//             var arr = list.ToArray();
//             var L = 0; 
//             var R = arr.Length - 1;
            
//             while (L < R) {
//                 if (arr[L] != arr[R]) {
//                     return false;
//                 }
//                 L++;
//                 R--;
//             }
//         }

//         return true;
    }
}