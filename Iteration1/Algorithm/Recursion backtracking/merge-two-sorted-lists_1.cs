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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null && list2 == null) {
            return null;
        }
        
        var curL = list1;
        var curR = list2;
        
        var tail = new ListNode(-1, null);        
        var head = tail;
        
        while (curL != null || curR != null) {
            if (curL == null) {
                tail.next = curR;
                curR = curR.next;
            }
            else if (curR == null) {
                tail.next = curL;
                curL = curL.next;
            }
            else if (curL.val <= curR.val) {
                tail.next = curL;
                curL = curL.next;
            } else {
                tail.next = curR;
                curR = curR.next;
            }
            
            tail = tail.next;
        }
        
        return head.next;
    }
}