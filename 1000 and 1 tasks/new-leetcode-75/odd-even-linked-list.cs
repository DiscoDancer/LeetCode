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
    public ListNode OddEvenList(ListNode head) {
        var odd = true;

        var pOdd = new ListNode();
        var pEven = new ListNode();

        var pOddEnd = pOdd;
        var pEvenEnd = pEven; 

        var p = head;
        while (p != null) {
            var next = p.next;
            p.next = null;
            if (odd) {
                pOddEnd.next = p;
                pOddEnd = pOddEnd.next;
            }
            else {
                pEvenEnd.next = p;
                pEvenEnd = pEvenEnd.next;
            }

            odd = !odd;
            p = next;
        }

        var newHead = new ListNode();
        var newEnd = newHead;
        p = pOdd.next;

        while (p != null) {
            var next = p.next;
            p.next = null;
            newEnd.next = p;
            newEnd = newEnd.next;
            p = next;
        }

        p = pEven.next;
        while (p != null) {
            var next = p.next;
            p.next = null;
            newEnd.next = p;
            newEnd = newEnd.next;
            p = next;
        }

        return newHead.next;
    }
}