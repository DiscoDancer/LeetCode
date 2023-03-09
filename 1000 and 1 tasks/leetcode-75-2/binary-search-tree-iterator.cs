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

// Тут мне хватило знания итеративного inorder(а) = // https://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion/
// Но если его не знать, то пизда

public class BSTIterator {
    private Stack<TreeNode> _stack = new ();
    private TreeNode _cur = null;

    public BSTIterator(TreeNode root) {
        _cur = root;
    }
    
    public int Next() {
        while (_cur != null) {
            _stack.Push(_cur);
            _cur = _cur.left;
        }

        _cur = _stack.Pop();
        var result = _cur.val;
        _cur = _cur.right;

        return result;
    }
    
    public bool HasNext() {
        return _cur != null || _stack.Any();
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */