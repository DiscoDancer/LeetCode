import java.util.*;

class Solution {

    public ListNode reverseBetween(ListNode head, int left, int right) {
        if (head == null) {
            return null;
        }

        var initialHead = head;
        var index = 1;
        ListNode prev = null;
        while (head != null && index < left ) {
            prev = head;
            head = head.next;
            index++;
        }

        ListNode fakeHead = null;

        var p = head;
        var p0 = head;
        while (p != null && index <= right) {
            var next = p.next;
            p.next = fakeHead;
            fakeHead = p;

            p = next;
            index++;
        }

        if (p0 != p) {
            p0.next = p;
        }

        // fakeHead.next = p;

        if (prev != null) {
            prev.next = fakeHead;
            return initialHead;
        }

        return fakeHead;
    }
}