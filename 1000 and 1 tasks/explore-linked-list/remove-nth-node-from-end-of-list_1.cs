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

// смог вспомнить сам!
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var cur = head;
        var i = n;
        while (i > 0 && cur != null) {
            cur = cur.next;
            i--;
        }

        if (i != 0) {
            return null; 
        }
        if (cur == null) {
            return head.next;
        }

        var beg = head;
        ListNode prev = null;
        while (cur != null) {
            cur = cur.next;
            prev = beg;
            beg = beg.next;
        }

        var next = prev.next?.next;
        prev.next = next;
        return head;
    }
}