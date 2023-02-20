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
            p = p.next;
            totalCount++;
        }

        ListNode prevEnd = null;
        var curCount = 0;
        while (curCount < totalCount) {
            var cur1 = queue.Dequeue();
            var cur2 = stack.Pop();

            if (cur1 == cur2) {
                if (prevEnd != null)
                {
                    prevEnd.next = cur1;
                    cur1.next = null;
                }
                break;
            }

            if (prevEnd != null)
            {
                prevEnd.next = cur1;
            }
                
            cur1.next = cur2;
            cur2.next = null;
            prevEnd = cur2;
            curCount += 2;
        }
    }
}