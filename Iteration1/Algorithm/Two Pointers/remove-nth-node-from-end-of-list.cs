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
        var arr = new ListNode[30];
        
        int k = 0;
        var cur = head;
        while (cur != null) {
            arr[k++] = cur;
            cur = cur.next;
        }
        
        // remove first
        if (n == k) {
            return head.next;
        }
        
        // list size > 1 here
        
        // remove last
        if (n == 1) {
            arr[k-2].next = null; // made a mistake here, put -1
        }
        else { // list size here > 2 and it is middle case
            var i = k - n;
            arr[i - 1].next = arr[i + 1];
        }
        
        return head;
    }
}