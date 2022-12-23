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
    public ListNode DeleteDuplicates(ListNode head) {
        var p = head;
        ListNode prev = null;
        while (p != null) {
            if (prev != null && prev.val == p.val) {
                var tmp = p;
                prev.next = p.next;
                p.next = null;
                p = prev.next;
                continue;
            }

            prev = p;
            p = p.next;
        }

        return head;
    }
}