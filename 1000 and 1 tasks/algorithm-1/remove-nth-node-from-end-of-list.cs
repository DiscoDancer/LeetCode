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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var count = 0;
        var table = new ListNode[30];

        var p = head;
        while (p != null) {
            table[count++] = p;
            p = p.next;
        }

        var targetIndex = count - n;
        if (targetIndex == 0) {
            return head.next;
        }
        else if (targetIndex == count - 1) {
            table[targetIndex - 1].next = null;
            return head;
        }
        else {
            table[targetIndex].next = null;
            table[targetIndex - 1].next = table[targetIndex + 1];
            return head;
        }

        return null;
    }
}