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
public class Solution {
    public ListNode ReverseList(ListNode head) {
        var p = head;
        ListNode q = null;
        while (p != null) {
            var isolatedNode = p;
            p = p.next;
            isolatedNode.next = null;
            isolatedNode.next = q;
            q = isolatedNode;
        }

        return q;
    }
}