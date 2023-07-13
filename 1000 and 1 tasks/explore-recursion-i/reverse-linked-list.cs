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
    // рекурсивно и нет


    // 12
    public ListNode ReverseList(ListNode head) {
        var newHead = (ListNode)null;

        var cur = head;
        while (cur != null) {
            var tmp = cur;
            cur = cur.next;

            tmp.next = newHead;
            newHead = tmp;
        }

        return newHead;
    }
}