import java.util.*;

class Solution {

    public ListNode deleteDuplicates(ListNode head) {
        ListNode newHead = null;
        ListNode newTail = null;
        ListNode newTailPrev = null;

        var p = head;
        while (p != null) {
            if (newTail == null) {
                newHead = p;
                newTail = p;
                p = p.next;
            } else if (newTail.val == p.val) {
                var badVal = p.val;
                p = p.next;
                newTail = newTailPrev;
                if (newTail != null) {
                    newTail.next = null;
                }
                else {
                    newHead = null;
                }

                while (p != null && p.val == badVal) {
                    p = p.next;
                }
            }
            else {
                newTailPrev = newTail;
                newTail.next = p;
                newTail = p;
                var next = p.next;
                p.next = null;
                p = next;
            }
        }

        return newHead;
    }
}