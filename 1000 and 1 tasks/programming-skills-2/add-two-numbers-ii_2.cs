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
 // https://leetcode.com/problems/add-two-numbers-ii/solutions/881521/add-two-numbers-ii/?orderBy=most_votes
public class Solution {
    private ListNode Reverse(ListNode head) {
        var last = (ListNode)null;
        var p = head;
        while (p != null) {
            var tmp = p.next;
            p.next = last;
            last = p;
            p = tmp;
        }

        return last;
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

        var fakeHead = new ListNode();
        var surplus = 0;
        var res = fakeHead;
        while (r1 != null && r2 != null) {
            var cur = r1.val + r2.val + surplus;
            res.next = new ListNode(cur % 10);
            surplus = cur / 10;
            res = res.next;
            r1 = r1.next;
            r2 = r2.next;
        }

        while (r1 != null) {
            var cur = r1.val + surplus;
            res.next = new ListNode(cur % 10);
            surplus = cur / 10;
            res = res.next;
            r1 = r1.next;
        }

        while (r2 != null) {
            var cur = r2.val + surplus;
            res.next = new ListNode(cur % 10);
            surplus = cur / 10;
            res = res.next;
            r2 = r2.next;
        }

        if (surplus > 0) {
            res.next = new ListNode(surplus);
        }

        return Reverse(fakeHead.next);
    }
}