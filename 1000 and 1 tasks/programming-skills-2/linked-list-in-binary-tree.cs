/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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
    private bool _found = false;

    // цепочка не должна прерываться
    // TL
    private void F(ListNode head, TreeNode root) {
        if (head == null) {
            _found = true;
            return;
        }

        if (_found || root == null) {
            return;
        }

        F(head, root.left);
        F(head, root.right);

        if (root.val == head.val) {
            if (head.next != null && (root.left != null || root.right != null) && (!(root.left != null && root.left.val == head.next.val || root.right != null && root.right.val == head.next.val)) ) {
                return;
            }
            else {   
                F(head.next, root.left);
                F(head.next, root.right);
            }
        }
    }

    public bool IsSubPath(ListNode head, TreeNode root) {
        F(head, root);
        return _found;
    }
}