import java.util.*;

class Solution {

    private static int GetLength(ListNode head) {
        int length = 0;
        while (head != null) {
            length++;
            head = head.next;
        }
        return length;
    }

    private static ListNode GetLast(ListNode head) {
        while (head.next != null) {
            head = head.next;
        }
        return head;
    }

    public ListNode rotateRight(ListNode head, int k) {
        if (head == null || head.next == null) {
            return head;
        }

        // нужно найти k с конца
        // но я не могу k по модулю сходу взять
        // поэтому сначала найду длину

        var length = GetLength(head);
        var last = GetLast(head);
        k = k % length;
        if (k == 0) {
            return head;
        }
        var m = length - k;
        var pm = head;
        ListNode pmPrev = null;
        for (int i = 0; i < m; i++) {
            pmPrev = pm;
            pm = pm.next;
        }
        if (pmPrev != null) {
            pmPrev.next = null;
        }

        last.next = head;
        return pm;
    }
}