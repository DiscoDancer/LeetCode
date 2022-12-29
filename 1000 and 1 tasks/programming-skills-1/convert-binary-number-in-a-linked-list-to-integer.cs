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
        var p = head;
        while (p != null && p.val == 0) {
            p = p.next;
        }

        if (p == null) {
            return 0;
        }

        var res = 1;
        p = p.next;
        while (p != null) {
            res = res << 1;
            if (p.val == 1) {
                res = res | 1;
            }
            p = p.next;
        }

        return res;
    }
}