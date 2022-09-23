using System.Collections.Generic;

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
    
    // always right;
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
        var stack = new Stack<TreeNode[]>();
        
        if (root1 == null) {
            return root2;
        }
        else if (root2 == null) {
            return root1;
        }
        
        stack.Push(new TreeNode[] {root1, root2});
        
        // for both 1st is not null
        while (stack.Any()) {
            var cur = stack.Pop();
            var l = cur[0];
            var r = cur[1];
            
            if (l == null || r == null) {
                continue;
            }
            
            r.val += l.val;
            if (r.left == null) {
                r.left = l.left;
            }
            else {
                stack.Push(new TreeNode[] {l.left, r.left});
            }
            if (r.right == null) {
                r.right = l.right;
            }
            else {
                stack.Push(new TreeNode[] {l.right, r.right});
            }
        }
            
        return root2;
    }
    
    public TreeNode MergeTrees2(TreeNode root1, TreeNode root2) {
        if (root1 == null && root2 == null) {
            return null;
        }
        
        TreeNode newRoot;
        
        if (root1 == null) {
            newRoot = root2;
        }
        else if (root2 == null) {
            newRoot = root1;
        }
        else {
            newRoot = root2;
            newRoot.val = root1.val + root2.val;
            newRoot.left = MergeTrees(root1.left, root2.left);
            newRoot.right = MergeTrees(root1.right, root2.right);
        }
        
        return newRoot;
    }
}