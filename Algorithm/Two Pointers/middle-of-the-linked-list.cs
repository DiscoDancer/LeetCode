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
    public ListNode MiddleNode(ListNode head) {
        const int possibleZide = 100;
        var arr = new ListNode[possibleZide];
        
        int k = 1;
        var cur = head;
        arr[0] = cur;
        while (cur.next != null) {
            cur = cur.next;
            arr[k++] = cur;
        }
        
        return arr[k / 2];
    }
}