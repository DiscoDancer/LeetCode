import java.util.*;


class Solution {
    public ListNode deleteDuplicates(ListNode head) {
        var sentinel = new ListNode(1001);
        var sentinelEnd = sentinel;

        var p = head;
        while (p != null) {
            var next = p.next;
            p.next = null;
            if (p.val != sentinelEnd.val) {
                sentinelEnd.next = p;
                sentinelEnd = sentinelEnd.next;
            }
            p = next;
        }

        return sentinel.next;
    }
}