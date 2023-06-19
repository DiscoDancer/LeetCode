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
    // можно сделать вращение
    // оптимизация по модулю
    // или просто расщипить на два и сщипить

    private int GetLength(ListNode head) {
        var length = 0;
        while (head != null) {
            length++;
            head = head.next;
        }

        return length;
    }

    public ListNode RotateRight(ListNode head, int k) {
        var length = GetLength(head);
        if (length == 0) {
            return head;
        }

        k = k % length;
        if (k == 0) {
            return head;
        }

        var firstHalfLength = length - k;
        var cur = head;
        var i = 1;
        while (i < firstHalfLength) {
            cur = cur.next;
            i++;
        }

        // здесь начинается вторая часть
        var newHead = cur.next;
        cur.next = null;

        var cur2 = newHead;
        while (cur2.next != null) {
            cur2 = cur2.next;
        }
        cur2.next = head;

        return newHead;
    }
}