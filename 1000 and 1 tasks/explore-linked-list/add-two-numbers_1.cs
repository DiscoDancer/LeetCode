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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var p1 = l1;
        var p2 = l2;

        var surplus = 0;
        var fakeHead = new ListNode();
        var fakeTail = fakeHead;

        while (p1 != null && p2 != null) {
            var sum = p1.val + p2.val + surplus;
            var res = sum % 10;
            surplus = sum / 10;

            p1 = p1.next;
            p2 = p2.next;
            fakeTail.next = new ListNode(res);
            fakeTail = fakeTail.next;
        }

        var p3 = p1 ?? p2;
        while (p3 != null) {
            var sum = p3.val + surplus;
            var res = sum % 10;
            surplus = sum / 10;

            fakeTail.next = new ListNode(res);
            fakeTail = fakeTail.next;

            p3 = p3.next;
        }

        if (surplus > 0) {
            fakeTail.next = new ListNode(surplus);
            fakeTail = fakeTail.next;
        }

        return fakeHead.next;
    }
}