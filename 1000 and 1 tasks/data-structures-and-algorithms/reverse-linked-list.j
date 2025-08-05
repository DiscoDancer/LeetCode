import java.util.*;


class Solution {
    public ListNode reverseList(ListNode head) {
        ListNode sentinel = null;

        var p = head;
        while (p != null) {
            var next = p.next;

            p.next = sentinel;
            sentinel = p;

            p = next;
        }

        return sentinel;
    }
}