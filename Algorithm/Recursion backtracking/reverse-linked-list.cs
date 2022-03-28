

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
    
    private ListNode _acc;
    
    public void F(ListNode head) {
        if (head.next != null) {
            // not last
            F(head.next);
            
            // acc.next = head;
            // acc = head;
           
            // int k = head.val;
            // head.val = prev;
            // prev = k;
        }
        else {
            // head.val = acc;
            // last
        }
        
        _acc.next = new ListNode(head.val);
        _acc = _acc.next;
    }
    
    public ListNode ReverseList(ListNode head) {
        if (head == null) {
            return null;
        }
        
        var firstVal = head.val;
        
        // prev = head.val;
        
        _acc = new ListNode(-1, null);
        var p = _acc;
        
        F(head);
        
        return p.next;
    }
}