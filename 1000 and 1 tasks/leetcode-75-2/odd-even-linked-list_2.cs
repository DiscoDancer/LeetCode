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
        var oddListHead = new ListNode();
        var evenListHead = new ListNode();

        var p = head;
        var isNextOdd = true;
        var oddListPointer = oddListHead;
        var evenListPointer = evenListHead;
        while (p != null) {
            var tmp = p;
            p = p.next;
            tmp.next = null;

            if (isNextOdd) {
                oddListPointer.next = tmp;
                oddListPointer = oddListPointer.next;
            }
            else {
                evenListPointer.next = tmp;
                evenListPointer = evenListPointer.next;
            }

            isNextOdd = !isNextOdd;
        }

        var fakeHead = new ListNode();
        p = fakeHead;

        oddListPointer = oddListHead.next;
        while (oddListPointer != null) {
            var tmp = oddListPointer;
            oddListPointer = oddListPointer.next;
            tmp.next = null;

            p.next = tmp;
            p = p.next;
        }

        
        evenListPointer = evenListHead.next;
        while (evenListPointer != null) {
            var tmp = evenListPointer;
            evenListPointer = evenListPointer.next;
            tmp.next = null;

            p.next = tmp;
            p = p.next;
        }

        return fakeHead.next;
    }
}