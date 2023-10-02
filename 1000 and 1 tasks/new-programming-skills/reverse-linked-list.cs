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
        ListNode? newHead = null;

        var p = head;
        while (p != null) {
            var tmp = p;
            p = p.next;

            tmp.next = newHead;
            newHead = tmp;
        }

        return newHead;
    }
}