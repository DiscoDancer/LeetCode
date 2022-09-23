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
    public ListNode RemoveElements(ListNode head, int val) {
        
        if (head == null) {
            return null;
        }
        
        while (head != null && head.val == val) {
            head = head.next;
        }
        
        // not in first
        
        ListNode prev = null;
        var cur = head;
        
        while (cur != null) {
            
            if (cur.val == val) {
                prev.next = cur.next;
                cur = cur.next;
            } else {
                prev = cur;
                cur = cur.next;
            }
        }
        
        return head;
    }
}