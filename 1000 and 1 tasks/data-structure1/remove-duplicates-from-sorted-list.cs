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
    public ListNode DeleteDuplicates(ListNode head) {
        var p = head;
        var fakeHead = new ListNode(int.MinValue, null);
        var q = fakeHead;
        while (p != null) {
            if (p.val != q.val) {
                q.next = p;
                q = q.next;
            }

            var prev = p;
            p = p.next;
            prev.next = null;
        }

        var res = fakeHead.next;
        fakeHead.next = null;
        return res;
    }
}