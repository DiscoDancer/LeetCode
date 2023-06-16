/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        var stack1 = new Stack<ListNode>();
        var stack2 = new Stack<ListNode>();

        var cur = headA;
        while (cur != null) {
            stack1.Push(cur);
            cur = cur.next;
        }

        cur = headB;
        while (cur != null) {
            stack2.Push(cur);
            cur = cur.next;
        }

        ListNode result = null;

        while (stack1.Any() && stack2.Any() && stack1.Peek() == stack2.Peek() ) {
            result = stack1.Pop();
            stack2.Pop();
        }

        return result;
    }
}