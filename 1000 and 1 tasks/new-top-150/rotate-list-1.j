import java.util.*;

class Solution {
    // нужно найти k с конца
    // но я не могу k по модулю сходу взять
    // поэтому сначала найду длину
    public ListNode rotateRight(ListNode head, int k) {
        if (head == null) {
            return head;
        }

        var length = 1;
        ListNode last = head;
        while (last.next != null) {
            last = last.next;
            length++;
        }

        k = k % length;
        if (k == 0) {
            return head;
        }
        var m = length - k;

        var lastLeft = head;
        for (int i = 0; i < m - 1; i++) {
            lastLeft = lastLeft.next;
        }

        var newHead = lastLeft.next;
        lastLeft.next = null;
        last.next = head;

        return newHead;
    }
}