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
 // https://leetcode.com/problems/binary-search-tree-iterator/solutions/306914/binary-search-tree-iterator/?orderBy=most_votes
public class BSTIterator {

    private Stack<TreeNode> _stack = new ();

    private void LeftMost(TreeNode node) {
        while (node != null) {
            _stack.Push(node);
            node = node.left;
        }
    }

    public BSTIterator(TreeNode root) {
        LeftMost(root);
    }
    
    public int Next() {
        var top = _stack.Pop();
        LeftMost(top.right);
        return top.val;
    }
    
    public bool HasNext() {
        return _stack.Any();
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */