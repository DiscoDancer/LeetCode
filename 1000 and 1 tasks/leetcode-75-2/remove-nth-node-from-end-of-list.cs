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
    private int GetLength(ListNode head) {
        var p = head;
        var l = 0;
        while (p != null) {
            l++;
            p = p.next;
        }

        return l;
    }

    // по модулю не надо брать
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var length = GetLength(head);
        var targetIndex = length - n;

        var p = head;
        ListNode prev = null;
        var i = 0;
        while (i < targetIndex) {
            prev = p;
            p = p.next;
            i++;
        }

        if (prev == null) {
            head = head.next;
            return head;
        }

        prev.next = p.next;
        p.next = null;
        return head;
    }
}