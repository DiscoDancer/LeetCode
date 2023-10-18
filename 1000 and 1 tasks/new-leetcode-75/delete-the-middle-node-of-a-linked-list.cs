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

    private ListNode FindMiddle(ListNode head) {
        var slow = head;
        var fast = head.next;

        while (fast != null) {
            slow = slow.next;
            fast = fast?.next?.next;
        }

        return slow;
    }


    public ListNode DeleteMiddle(ListNode head) {
        var target = FindMiddle(head);
        if (target == head) {
            return null;
        }
        ListNode? prev = null;

        var p = head;
        while (p != target) {
            prev = p;
            p = p.next;
        }

        prev.next = target.next;

        return head;
    }
}