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
    private (int, ListNode) GetLengthAndLast(ListNode head) {
        var p = head;
        ListNode last = null;
        int length = 0;
        while (p != null) {
            if (p.next == null) {
                last = p;
            }
            p = p.next;
            length++;
        }
        return (length, last);
    }

    public ListNode RotateRight(ListNode head, int k) {
        if (head == null) {
            return null;
        }

        var (length, last) = GetLengthAndLast(head);
        k = k % length;

        if (k == 0) {
            return head;
        }

        var sizeLeft = length - k;

        var p = head;
        int i = 0;
        while (i < sizeLeft) {
            var tmp = p;
            p = p.next;
            tmp.next = null;
            last.next = tmp;
            last = last.next;
            head = p;
            i++;
        }


        return head;
    }
}