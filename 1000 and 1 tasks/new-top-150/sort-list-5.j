/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */

 // no add memory
class Solution {

    private int length(ListNode head) {
        int len = 0;
        while (head != null) {
            len++;
            head = head.next;
        }
        return len;
    }

    // Merge Sort
    // вопрос в том, нужен ли мне конец интервала
    // я могу оперировать длиной временно
    private void F(ListNode head, int intervalLength) {
        // could be 0?
        if (intervalLength < 2) {
            return;
        }
        if (intervalLength == 2) {
            if (head.val > head.next.val) {
                swap(head, head.next);
            }
            return;
        }

        var lLength = intervalLength / 2;
        // if m exists, it comes to the right
        var rLength = intervalLength - lLength;

        // sort l
        F(head, lLength);

        // sort r
        var pRight = head;
        for (int i = 0; i < lLength; i++) {
            pRight = pRight.next;
        }
        F(pRight, rLength);

        var pLeft = head;


        var lCount = lLength;
        var rCount = intervalLength - lLength;

        var fakeHead = new ListNode(0, head);
        var fakeTail = fakeHead;
        ListNode lastNext = head;
        for (int i = 0; i < intervalLength; i++) {
            lastNext = lastNext.next;
        }

        for (int arrIndex = 0; arrIndex < intervalLength; arrIndex++) {
            if (lCount > 0 && rCount > 0 && pLeft.val <= pRight.val || lCount > 0 && rCount == 0) {
                // append to new list
                var next = pLeft.next;
                pLeft.next = null;
                fakeTail.next = pLeft;
                pLeft = next;
                lCount--;
            } else if (lCount > 0 && rCount > 0 || rCount > 0 && lCount == 0) {
                // append to new list
                var next = pRight.next;
                pRight.next = null;
                fakeTail.next = pRight;
                pRight = next;
                rCount--;
            }
            fakeTail = fakeTail.next;
        }

        // new list here is properly sorted

        // fix end connection
        fakeTail.next = lastNext;

        // now we need a prev to head in this list to fix begin connection
        var prevHead = fakeHead;
        var q = fakeHead;
        while (q != head) {
            prevHead = q;
            q = q.next;
        }
        // we need to switch places head and factual head
        // if only we need to do so
        if (fakeHead.next != head) {
            // prevHead
            var nextHead = head.next;

            var actualHead = fakeHead.next;

            if (actualHead.next == head) {
                actualHead.next = nextHead;
                head.next = actualHead;

            } else {
                var actualHeadNext = actualHead.next;

                actualHead.next = nextHead;
                head.next = actualHeadNext;
                prevHead.next = actualHead;
            }
            swap(actualHead, head);
        }
    }

    public void swap(ListNode a, ListNode b) {
        var t = a.val;
        a.val = b.val;
        b.val = t;
    }

    public ListNode sortList(ListNode head) {
        var l = length(head);
        F(head, l);
        return head;
    }
}