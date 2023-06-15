/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        if (head == null) {
            return false;
        }

        var slow = head;
        var fast = head.next;

        while (slow != fast) {
            slow = slow?.next;
            fast = fast?.next?.next;

            if (slow == null || fast == null) {
                return false;
            }
        }

        return true;
    }
}