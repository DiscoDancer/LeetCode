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
public class Solution
{
    public enum ParentState
    {
        Root,
        Left,
        Right
    }

    private TreeNode InorderSuccessor(TreeNode root, TreeNode p)
    {
        var leftMost = root;
        var stack = new Stack<TreeNode>();

        TreeNode? prev = null;

        while (leftMost != null || stack.Any())
        {
            while (leftMost != null)
            {
                stack.Push(leftMost);
                leftMost = leftMost.left;
            }

            var cur = stack.Pop();
            if (p == prev)
            {
                return cur;
            }
            prev = cur;

            leftMost = cur.right;
        }

        return null;
    }

    // украл идею отсюда https://www.geeksforgeeks.org/deletion-in-binary-search-tree/
    // про то, что successor надо искать
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root == null) return null;

        var parentState = ParentState.Root;
        TreeNode parent = null;
        var p = root;

        while (p != null)
            if (p.val == key)
            {
                if (p.left == null && p.right == null)
                {
                    if (parentState == ParentState.Root) return null;

                    if (parentState == ParentState.Left)
                        parent.left = null;
                    else if (parentState == ParentState.Right) parent.right = null;
                    return root;
                }
                else if (p.left == null && p.right != null)
                {
                    if (parentState == ParentState.Root)
                        return p.right;
                    if (parentState == ParentState.Left)
                        parent.left = p.right;
                    else if (parentState == ParentState.Right) parent.right = p.right;
                    return root;
                }
                else if (p.left != null && p.right == null)
                {
                    if (parentState == ParentState.Root)
                        return p.left;
                    if (parentState == ParentState.Left)
                        parent.left = p.left;
                    else if (parentState == ParentState.Right) parent.right = p.left;
                    return root;
                }
                else if (p.left != null && p.right != null)
                {
                    var inorderSuccessor = InorderSuccessor(root, p);
                    p.val = inorderSuccessor.val;
                    key = inorderSuccessor.val;
                    parent = p;
                    parentState = ParentState.Right;
                    p = p.right;
                }
            }
            else if (key < p.val)
            {
                parent = p;
                parentState = ParentState.Left;
                p = p.left;
            }
            else if (key > p.val)
            {
                parent = p;
                parentState = ParentState.Right;
                p = p.right;
            }

        return root;
    }
}