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
        var stack = new Stack<ListNode>();

        var p = head;
        while (p != null) {
            stack.Push(p);
            p = p.next;
        }

        var fakeHead = new ListNode();
        var cur = fakeHead;
        while (stack.Any()) {
            cur.next = stack.Pop();
            cur = cur.next;
            cur.next = null;
        }

        var res = fakeHead.next;
        fakeHead.next = null;
        return res;
    }
}