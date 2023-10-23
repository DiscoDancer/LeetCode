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
    private TreeNode _parentLeft;
    private TreeNode _parentRight;
    private TreeNode _targetNode;
    private TreeNode _successor;
    private int _key;

    private const int FIND_NODE = 1;
    private const int FIND_SUCCESSOR = 2;
    private const int DONE = 3;
    private int _state;

    private void Inorder(TreeNode root, TreeNode parentLeft, TreeNode parentRight) {
        if (_state == DONE) {
            return;
        }

        if (root.left != null) {
            Inorder(root.left, root, null);
        }

        // proccess
        if (_state == FIND_NODE) {
            if (root.val == _key) {
                _targetNode = root;
                _parentLeft = parentLeft;
                _parentRight = parentRight;
                _state = FIND_SUCCESSOR;
            }
        }
        else if (_state == FIND_SUCCESSOR) {
            _successor = root;
            _state = DONE;
            return;
        }

        if (root.right != null) {
            Inorder(root.right, null, root);
        }
    }

    public TreeNode DeleteNode(TreeNode root, int key) {
        if (root == null) {
            return null;
        }

        _parentLeft = null;
        _parentRight = null;
        _targetNode = null;
        _successor = null;
        _state = FIND_NODE;
        _key = key;

        Inorder(root, null, null);

        if (_targetNode == null) {
            return root;
        }

        // case 1: leaf
        if (_targetNode.left == null && _targetNode.right == null) {
            if (_parentLeft != null) {
                _parentLeft.left = null;
            }
            else if (_parentRight != null) {
                _parentRight.right = null;
            }
            else {
                return null;
            }
            return root;
        }
        // case 2: 1 child only
        else if (_targetNode.left == null ^ _targetNode.right == null) {
            var child = _targetNode.left != null ? _targetNode.left : _targetNode.right;
            if (_parentLeft != null) {
                _parentLeft.left = child;
            }
            else if (_parentRight != null) {
                _parentRight.right = child;
            }
            else {
                return child;
            }
            return root;
        }
        // case 3: 2 children
        else {
            var tmp = _targetNode.val;
            _targetNode.val = _successor.val;
            _successor.val = tmp;
            return DeleteNode(root, tmp);
        }

        throw new Exception();
    }
}