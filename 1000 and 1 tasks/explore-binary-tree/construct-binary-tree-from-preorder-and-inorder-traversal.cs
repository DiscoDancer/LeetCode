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

// editorial 
public class Solution {
    private int[] _preorder;
    private int[] _inorder;
    private Dictionary<int, int> _inorderValueToIndex = new ();
    private int preorderIndex = 0;

    private TreeNode Build(int inorderLeftIndex, int inorderRightIndex) {
        if (inorderLeftIndex > inorderRightIndex) {
            return null;
        }

        var currentNode = new TreeNode(_preorder[preorderIndex]);
        preorderIndex++;

        var inorderIndex = _inorderValueToIndex[currentNode.val];

        currentNode.left = Build(inorderLeftIndex, inorderIndex - 1);
        currentNode.right = Build(inorderIndex + 1, inorderRightIndex);

        return currentNode;
    }

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        _preorder = preorder;
        _inorder = inorder;
        for (int i = 0; i < _inorder.Length; i++) {
            _inorderValueToIndex[_inorder[i]] = i;
        }

        return Build(0, inorder.Length - 1);
    }
}