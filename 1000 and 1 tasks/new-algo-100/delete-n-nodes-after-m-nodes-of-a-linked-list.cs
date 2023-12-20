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
    public const int Keep = 1;
    public const int Delete = 2;

    public ListNode DeleteNodes(ListNode head, int m, int n) {
        var cur = head;
        ListNode prev = null;
        var state = Keep;
        while (cur != null) {
            if (state == Keep) {
                var i = 0;
                while (cur != null && i < m) {
                    prev = cur;
                    cur = cur.next;
                    i++;
                }
                state = Delete;
            }
            else if (state == Delete) {
                var i = 0;
                while (cur != null && i < n) {
                    var next = cur.next;
                    prev.next = next;
                    cur = next;
                    i++;
                }
                state = Keep;
            }
        }
        return head;
    }
}