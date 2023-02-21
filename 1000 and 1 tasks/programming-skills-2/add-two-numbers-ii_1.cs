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
    private ListNode Reverse(ListNode head) {
        var p = head;
        var stack = new Stack<ListNode>();
        while (p != null) {
            var tmp = p;
            p = p.next;
            tmp.next = null;
            stack.Push(tmp);
        }

        var fakeHead = new ListNode();
        var q = fakeHead;
        while (stack.Any()) {
            q.next = stack.Pop();
            q = q.next;
        }

        return fakeHead.next;
    }

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        if (l1 == null) {
            return l2;
        }
        if (l2 == null) {
            return l1;
        }

        var stack1 = new Stack<ListNode>();
        var stack2 = new Stack<ListNode>();

        var p = l1;
        while (p != null) {
            var tmp = p;
            p = p.next;
            tmp.next = null;
            stack1.Push(tmp);
        }
        p = l2;
        while (p != null) {
            var tmp = p;
            p = p.next;
            tmp.next = null;
            stack2.Push(tmp);
        }

        var fakeHead = new ListNode();
        var surplus = 0;
        var res = fakeHead;
        while (stack1.Any() && stack2.Any()) {
            var p1 = stack1.Pop();
            var p2 = stack2.Pop();

            var cur = p1.val + p2.val + surplus;
            res.next = new ListNode(cur % 10);
            surplus = cur / 10;
            res = res.next;
        }

        while (stack1.Any()) {
            var p1 = stack1.Pop();
            var cur = p1.val + surplus;
            res.next = new ListNode(cur % 10);
            surplus = cur / 10;
            res = res.next;
        }

        while (stack2.Any()) {
            var p2 = stack2.Pop();
            var cur = p2.val + surplus;
            res.next = new ListNode(cur % 10);
            surplus = cur / 10;
            res = res.next;
        }

        if (surplus > 0) {
            res.next = new ListNode(surplus);
        }

        return Reverse(fakeHead.next);
    }
}