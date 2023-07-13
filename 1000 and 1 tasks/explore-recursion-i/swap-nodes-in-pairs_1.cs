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
    // editorial
    public ListNode SwapPairs(ListNode head) {
        if (head?.next == null) {
            return head;
        }

        var a = head;
        var b = head.next;

        a.next = SwapPairs(b.next);
        b.next = a;

        return b;
    }
}