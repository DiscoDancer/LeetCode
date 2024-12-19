import java.util.*;

class Solution {
    public ListNode partition(ListNode head, int x) {
        var leftPartHead = new ListNode(-1);
        var leftPartTail = leftPartHead;
        var rightPartHead = new ListNode(-1);
        var rightPartTail = rightPartHead;

        var p = head;
        while (p != null) {
            var next = p.next;
            if (p.val < x) {
                leftPartTail.next = p;
                leftPartTail = p;
                leftPartTail.next = null;
            } else {
                rightPartTail.next = p;
                rightPartTail = p;
                rightPartTail.next = null;
            }
            p = next;
        }

        leftPartTail.next = rightPartHead.next;

        return leftPartHead.next;
    }
}