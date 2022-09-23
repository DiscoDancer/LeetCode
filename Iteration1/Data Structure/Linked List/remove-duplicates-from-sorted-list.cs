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
        if (head == null) {
            return null;
        }
        
        // remove from head
        while (head != null && head.next != null && head.val == head.next.val) {
            head = head.next;
        }
        
        var cur = head.next;
        var prev = head;
        
        while (cur != null) {
            if (prev.val == cur.val) {
                prev.next = cur.next;
                cur = cur.next;
            }
            else {
                prev = cur;
                cur = cur.next;
            }
        }
        
        return head;        
    }
}