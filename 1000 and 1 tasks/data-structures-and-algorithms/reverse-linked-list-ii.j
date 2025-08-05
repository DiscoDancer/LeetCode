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

    public ListNode reverseBetween(ListNode head, int left, int right) {
        var leftSentinel = new ListNode(-1);
        var leftSentinelEnd = leftSentinel;

        var middleSentinel = new ListNode(-1);
        var middleSentinelEnd = middleSentinel;

        var rightSentinel = new ListNode(-1);
        var rightSentinelEnd = rightSentinel;

        var p = head;
        var i = 1;
        while (p != null) {
            var next = p.next;
            p.next = null;

            // add
            if (i < left) {
                leftSentinelEnd.next = p;
                leftSentinelEnd = leftSentinelEnd.next;
            }
            else if (i > right) {
                rightSentinelEnd.next = p;
                rightSentinelEnd = rightSentinelEnd.next;
            }
            else {
                middleSentinelEnd.next = p;
                middleSentinelEnd = middleSentinelEnd.next;
            }

            p = next;
            i++;
        }
        
        // reverse middle
        var middleHead = middleSentinel.next;
        var middleNewHead = reverseList(middleHead);

        // add right
        middleHead.next = rightSentinel.next;

        // add left
        leftSentinelEnd.next = middleNewHead;

        return leftSentinel.next;
    }
}