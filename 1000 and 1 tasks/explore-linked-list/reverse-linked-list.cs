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
    public ListNode ReverseList(ListNode head) {
        if (head == null) {
            return null;
        }

        var stack = new Stack<ListNode>();

        var cur = head;
        while (cur != null) {
            var p = cur;
            stack.Push(p);
            cur = cur.next;
            p.next = null;
        }

        var fakeHead = new ListNode(-1);
        cur = fakeHead;
        while (stack.Any()) {
            cur.next = stack.Pop();
            cur = cur.next;
        }

        return fakeHead.next;
    }
}