import java.util.Comparator;
import java.util.LinkedList;
import java.util.PriorityQueue;
import java.util.Queue;

// pq is really game changer here, because of nlogm

class Solution {
    public ListNode mergeKLists(ListNode[] lists) {

        var fakeHead = new ListNode(-1);
        var fakeTail = fakeHead;

        var queue = new PriorityQueue<ListNode>(Comparator.comparingInt(a -> a.val));
        for (var list : lists) {
            if (list != null) {
                queue.add(list);
            }
        }

        while (!queue.isEmpty()) {
            var minHead = queue.poll();
            var minNext = minHead.next;
            if (minNext != null) {
                queue.add(minNext);
            }
            fakeTail.next = minHead;
            fakeTail = minHead;
            fakeTail.next = null;
        }

        return fakeHead.next;
    }
}