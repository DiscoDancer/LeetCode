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

    private int GetLength(ListNode head) {
        var p = head;
        var length = 0;
        while (p != null) {
            length++;
            p = p.next;
        }

        return length;
    }

    private void Sum(ListNode big, ListNode small, int surplus = 0) {
        var cur = big.val + (small == null ? 0 : small.val) + surplus;
        var nextSurplus = cur / 10;
        big.val = cur % 10;
        if (big.next == null)
        {
            if (nextSurplus > 0)
            {
                big.next = new ListNode(nextSurplus);

            }
            return;
        }
        Sum(big.next, small == null ? null : small.next, nextSurplus);
    }

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        if (l1 == null) {
            return l2;
        }
        if (l2 == null) {
            return l1;
        }

        var r1 = Reverse(l1);
        var r2 = Reverse(l2);

        var size1 = GetLength(r1);
        var size2 = GetLength(r2);

        var big = size1 >= size2 ? r1 : r2;
        var small = big == r1 ? r2 : r1;

        Sum(big, small);
        return Reverse(big);
    }
}