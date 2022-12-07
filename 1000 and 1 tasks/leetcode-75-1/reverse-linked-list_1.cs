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

 // рекурсия помогла бы
 // мб можно на месте просто через prev?
public class Solution {
    public ListNode ReverseList(ListNode head) {
        var p = head;
        var prev = (ListNode) null;
        while (p != null) {
            if (prev == null) {
                var next = p.next;
                p.next = null;
                prev = p;
                p = next;
            } else {
               var next = p.next;
               p.next = prev;
               prev = p;
               p = next;
            }
        }

        return prev;
    }
}