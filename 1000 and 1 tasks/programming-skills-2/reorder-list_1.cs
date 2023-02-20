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
    // fake head + stack + queue
    // just list
    public void ReorderList(ListNode head) {
        if (head == null) {
            return;
        }

        var p = head;
        var queue = new Queue<ListNode>();
        var stack = new Stack<ListNode>();
        var totalCount = 0;
        while (p != null) {
            queue.Enqueue(p);
            stack.Push(p);
            var tmp = p;
            p = p.next;
            tmp.next = null;
            totalCount++;
        }

        ListNode prevEnd = null;
        var curCount = 0;
        while (curCount < totalCount) {
            var cur1 = queue.Dequeue();
            var cur2 = stack.Pop();

            if (prevEnd != null)
            {
                prevEnd.next = cur1;
            }
            
            if (cur2 != cur1) {
                cur1.next = cur2;
                curCount += 2;
                prevEnd = cur2;
            }
            else {
                curCount += 1;
                prevEnd = cur1;
            }
        }
    }
}