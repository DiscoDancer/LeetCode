import java.util.*;

class Solution {

    private ListNode reverse(ListNode head) {
        ListNode newHead = null;
        var p = head;
        while (p != null) {
            var next = p.next;
            p.next = newHead;
            newHead = p;
            p = next;
        }
        return newHead;
    }

    public ListNode reverseKGroup(ListNode head, int k) {
        var fakeHeadGlobalHead = new ListNode(-1);
        var fakeHeadGlobalTail = fakeHeadGlobalHead;

        var fakeHeadBufferHead = new ListNode(-1);
        var fakeHeadBufferTail = fakeHeadBufferHead;
        var bufferSize = 0;

        var p = head;
        while (p != null) {
            var next = p.next;
            p.next = null;

            fakeHeadBufferTail.next = p;
            fakeHeadBufferTail = fakeHeadBufferTail.next;
            bufferSize++;
            if (bufferSize == k || next == null) {
                if (bufferSize == k) {
                    // reverse
                    var reversedHead = fakeHeadBufferHead.next;
                    fakeHeadGlobalTail.next = reverse(reversedHead);
                    fakeHeadGlobalTail = reversedHead;

                    fakeHeadBufferHead = new ListNode(-1);
                    fakeHeadBufferTail = fakeHeadBufferHead;
                    bufferSize = 0;
                } else {
                    // not reverse
                    var reversedHead = fakeHeadBufferHead.next;
                    fakeHeadGlobalTail.next = reversedHead;

                }
            }

            p = next;
        }

        return fakeHeadGlobalHead.next;
    }
}