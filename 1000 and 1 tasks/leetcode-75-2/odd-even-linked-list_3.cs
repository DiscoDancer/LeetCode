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

 // https://leetcode.com/problems/odd-even-linked-list/editorial/
public class Solution {
    public ListNode OddEvenList(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }

        var oddPointer = head;
        var evenPointer = head.next;
        var evenHead = evenPointer;

        while (evenPointer != null && evenPointer.next != null) {
            oddPointer.next = evenPointer.next;
            oddPointer = oddPointer.next;
            evenPointer.next = oddPointer.next;
            evenPointer = evenPointer.next;
        }

        oddPointer.next = evenHead;
        return head;
    }
}