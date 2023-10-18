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
    // длина, середина

    // делаем reverse от середины
    // через find middle можно узнать четность

    private (ListNode, bool) FindMiddle(ListNode head) {
        var slow = head;
        var fast = head.next;

        var even = false;

        while (fast != null) {
            slow = slow.next;

            if (fast.next == null) {
                even = true;
            }

            fast = fast?.next?.next;
        }

        return (slow, even);
    }

    public ListNode ReverseList(ListNode head) {
        ListNode fakeHead = null;

        var p = head;
        while (p != null) {
            var next = p.next;
            p.next = null;

            p.next = fakeHead;
            fakeHead = p;

            p = next;
        }

        return fakeHead;
    }

    // 1 2 3 4 -> 1 2 4 3
    public int PairSum(ListNode head) {
        var (middle, even) = FindMiddle(head);

        var reversedSecondHalf = even ? ReverseList(middle) : ReverseList(middle.next);

        var fakeHead = new ListNode();
        var fakeEnd = fakeHead;

        var p = head;
        var q = reversedSecondHalf;

        var max = int.MinValue;

        while (q != null) {
            max = Math.Max(max, p.val + q.val);

            p = p.next;
            q = q.next;
        }

        return max;
    }
}