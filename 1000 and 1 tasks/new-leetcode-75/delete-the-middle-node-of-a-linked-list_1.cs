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
    // find middle
    // delete

    public ListNode DeleteMiddle(ListNode head) {
        ListNode? prev = null;
        var slow = head;
        var fast = head.next;

        while (fast != null) {
            prev = slow;
            slow = slow.next;
            fast = fast?.next?.next;
        }

        if (slow == head) {
            return null;
        }

        prev.next = slow.next;

        return head;
    }
}