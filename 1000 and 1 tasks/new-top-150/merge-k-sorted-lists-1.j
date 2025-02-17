import java.util.LinkedList;
import java.util.Queue;

// naiive + remove empty lists, but extra memory

class Solution {
    public ListNode mergeKLists(ListNode[] lists) {

        var fakeHead = new ListNode(-1);
        var fakeTail = fakeHead;

        Queue<ListNode> queue = new LinkedList<>();
        for (var list : lists) {
            if (list != null) {
                queue.add(list);
            }
        }

        while (!queue.isEmpty()) {

            ListNode minHead = null;
            var minValue = Integer.MAX_VALUE;
            var newQueue = new LinkedList<ListNode>();
            while (!queue.isEmpty()) {
                var head = queue.poll();
                if (head.val < minValue) {
                    if (minHead != null) {
                        newQueue.add(minHead);
                    }
                    minHead = head;
                    minValue = head.val;
                } else {
                    newQueue.add(head);
                }
            }

            var minNext = minHead.next;
            if (minNext != null) {
                newQueue.add(minNext);
            }

            fakeTail.next = minHead;
            fakeTail = minHead;
            fakeTail.next = null;
            queue = newQueue;
        }

        return fakeHead.next;
    }
}