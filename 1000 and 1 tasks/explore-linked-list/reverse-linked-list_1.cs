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
    public ListNode ReverseList(ListNode head) {
        if (head == null) {
            return null;
        }

        var curOriginal = head;
        ListNode curNew = null;

        while (curOriginal != null) {
            var tmp = curOriginal;
            curOriginal = curOriginal.next;
            tmp.next = curNew;
            curNew = tmp;
        }

        return curNew;
    }
}