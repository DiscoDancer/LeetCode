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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var length = 0;
        var cur = head;
        while (cur != null) {
            length++;
            cur = cur.next;
        }

        // нужно вычислить prev

        // сколько левее
        var countLeft = length - n;
        if (countLeft < 0) {
            return null;
        }
        if (countLeft == 0) {
            return head.next;
        }

        var prev = head;
        var i = 0;
        while (i < countLeft - 1) {
            i++;
            prev = prev.next;
        }

        var next = prev.next?.next;
        prev.next = next;
        return head;
    }
}