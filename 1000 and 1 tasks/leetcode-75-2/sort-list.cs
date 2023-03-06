/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode SortList(ListNode head) {
        var minHeap = new PriorityQueue<ListNode, int>();

        var p = head;
        while (p != null) {
            var tmp = p;
            p = p.next;
            tmp.next = null;
            minHeap.Enqueue(tmp, tmp.val);
        }

        var fakeHead = new ListNode();
        p = fakeHead;
        while (minHeap.Count >= 1) {
            var min = minHeap.Dequeue();
            p.next = min;
            p = p.next;
        }

        return fakeHead.next;
    }
}