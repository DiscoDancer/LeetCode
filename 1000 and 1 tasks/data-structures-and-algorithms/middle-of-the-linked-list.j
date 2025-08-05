import java.util.*;


class Solution {
    public ListNode middleNode(ListNode head) {

        var slow = head;
        var fast = head;

        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next;
            if (fast != null) {
                fast = fast.next;
            }
        }

        return slow;
    }
}