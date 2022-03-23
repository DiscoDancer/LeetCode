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
        
        int k = 0;
        while (head != null) {
            arr[k++] = head;
            head = head.next;
        }
        
        return arr[k / 2];
    }
}