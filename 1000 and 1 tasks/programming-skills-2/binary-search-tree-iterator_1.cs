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
public class BSTIterator {

    private int _i = 0;
    private List<int> _list = new ();
    private Stack<TreeNode> _stack = new ();
    private TreeNode _cur = null;

    private void Inorder(TreeNode node) {
        if (node == null) {
            return;
        }

        var _cur = node;
        while (_cur != null || _stack.Any()) {
            while (_cur != null) {
                _stack.Push(_cur);
                _cur = _cur.left;
            }

            _cur = _stack.Pop();
            _list.Add(_cur.val);

            _cur = _cur.right;
        }
    }

    public BSTIterator(TreeNode root) {
        Inorder(root);
    }
    
    public int Next() {
        return _list[_i++];
    }
    
    public bool HasNext() {
        return _i < _list.Count();
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */