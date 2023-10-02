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
    // l1 l2 swap?
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var fakeHead = new ListNode(-1);
        var fakeTail = fakeHead;

        var p = l1;
        var q = l2;

        var surplus = 0;

        while (p != null && q != null) {
            var res = p.val + q.val + surplus;
            surplus = res / 10;
            fakeTail.next = new ListNode(res % 10);
            fakeTail = fakeTail.next;
            p = p.next;
            q = q.next;
        }

        while (p != null) {
            var res = p.val + surplus;
            surplus = res / 10;
            fakeTail.next = new ListNode(res % 10);
            fakeTail = fakeTail.next;
            p = p.next;
        }

        while (q != null) {
            var res = q.val + surplus;
            surplus = res / 10;
            fakeTail.next = new ListNode(res % 10);
            fakeTail = fakeTail.next;
            q = q.next;
        }

        if (surplus > 0) {
            fakeTail.next = new ListNode(surplus);
            fakeTail = fakeTail.next;
        }

        return fakeHead.next;
    }
}