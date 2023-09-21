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

// You may assume that next() calls will always be valid. 
    // см. решение validate-binary-search-tree.cs
public class BSTIterator
{

    private TreeNode _leftMost;
    private Stack<TreeNode> _stack;

    public BSTIterator(TreeNode root)
    {
        _leftMost = root;
        _stack = new();
    }

    public int Next()
    {
        while (_leftMost != null)
        {
            _stack.Push(_leftMost);
            _leftMost = _leftMost.left;
        }

        var cur = _stack.Pop();
        _leftMost = cur.right;

        return cur.val;
    }

    public bool HasNext()
    {
        return _leftMost != null || _stack.Any();
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */