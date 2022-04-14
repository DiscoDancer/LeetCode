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
    public int GetDecimalValue(ListNode head) {
        var cur = head;
        var leadingZero = true;
        var res = 0;
        while (cur != null) {
            if (leadingZero && cur.val == 1) {
                leadingZero = false;
                res = 1;
            }
            else if (!leadingZero) { // here we have not first `1`
                res = res << 1 + cur.val;
            }
            cur = cur.next;
        }
        
        return res;
    }
}