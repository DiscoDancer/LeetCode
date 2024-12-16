import java.util.*;

class Solution {

    public boolean hasCycle(ListNode head) {
        if (head == null || head.next == null || head.next.next == null) {
            return false;
        }

        var normalPointer = head;
        var fastPointer = head.next.next;

        while (normalPointer != null && fastPointer != null) {
            if (normalPointer == fastPointer) {
                return true;
            }
            normalPointer = normalPointer.next;
            fastPointer = fastPointer.next;
            if (fastPointer == null) {
                return false;
            }
            fastPointer = fastPointer.next;
        }

        return false;
    }
}