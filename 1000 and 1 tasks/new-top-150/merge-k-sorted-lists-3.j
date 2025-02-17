import java.util.Comparator;
import java.util.LinkedList;
import java.util.PriorityQueue;
import java.util.Queue;

// mem save approach

class Solution {

    private ListNode mergeTwoLists(ListNode a, ListNode b) {
        var dummy = new ListNode(-1);
        var current = dummy;

        while (a != null && b != null) {
            if (a.val < b.val) {
                current.next = a;
                a = a.next;
            } else {
                current.next = b;
                b = b.next;
            }

            current = current.next;
        }

        if (a != null) {
            current.next = a;
        } else {
            current.next = b;
        }

        return dummy.next;
    }

    public ListNode mergeKLists(ListNode[] lists) {
        if (lists == null || lists.length == 0) {
            return null;
        }

        var base = lists[0];
        for (int i = 1; i < lists.length; i++) {
            base = mergeTwoLists(base, lists[i]);
        }

        return base;
    }
}