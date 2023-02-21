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
    // уже reversed!
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

        var size1 = GetLength(l1);
        var size2 = GetLength(l2);

        var big = size1 >= size2 ? l1 : l2;
        var small = big == l1 ? l2 : l1;

        Sum(big, small);
        return big;
    }
}