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
        var fakeHead = new ListNode();

        var p = head;
        var q = fakeHead;
        while (p != null) {
            if (p.val != val) {
                q.next = p;
                q = q.next;
            }
            p = p.next;
        }

        q.next = null;
        var res = fakeHead.next;
        fakeHead.next = null;
        return res;
    }
}