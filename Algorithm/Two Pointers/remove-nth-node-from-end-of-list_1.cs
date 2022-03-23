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
        var first = head;
        var second = head;
        
        for (int i = 0; i < n; i++) {
            first = first.next;
        }
        
        if (first == null) {
            return head.next;
        }
        
        while (first != null && first.next != null) {
            first = first.next;
            second = second.next;
        }
        
        second.next = second.next.next;
        
        return head;
    }
}